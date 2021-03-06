Imports LFERP.DataSetting
Imports LFERP.Library.SampleManager.SampleOrdersMain
Imports LFERP.Library.SampleManager.SampleCollection
Imports LFERP.Library.SampleManager.SamplePace
Imports LFERP.Library.SampleManager.SampleStorage
Imports LFERP.Library.SampleManager.SamplePacking


Public Class frmSampleStorageAdd

#Region "属性和全局变量"
    Private _EditItem As String '属性栏位
    Property EditItem() As String '属性
        Get
            Return _EditItem
        End Get
        Set(ByVal value As String)
            _EditItem = value
        End Set
    End Property
    Private _SSID As Decimal '自动编号
    Property SSID() As Decimal '属性
        Get
            Return _SSID
        End Get
        Set(ByVal value As Decimal)
            _SSID = value
        End Set
    End Property
    Private _DID As String '部门编号
    Property DID() As String
        Get
            Return _DID
        End Get
        Set(ByVal value As String)
            _DID = value
        End Set
    End Property

    Dim ds As New DataSet
    Dim sscon As New SampleStorageController
    Dim sslcon As New SampleStorageLogController
    Dim Sccon As New SampleCollectionControler
    Dim somcon As New SampleOrdersMainControler
    Dim pkcom As New SamplePackingController
    Dim result As Boolean
    Dim spqList As New List(Of SamplePaceQueryInfo)
#End Region

#Region "创建临时表"
    ''' <summary>
    ''' 创建临时表
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateTable()
        ds.Tables.Clear()
        With ds.Tables.Add("SampleStorage")
            .Columns.Add("AutoID", GetType(Decimal))
            .Columns.Add("Code_ID", GetType(String))
            .Columns.Add("SE_ID", GetType(String))
            .Columns.Add("Qty", GetType(Decimal))
            .Columns.Add("ShelveID", GetType(String))
            .Columns.Add("StorageLocation", GetType(String))
        End With
        GridControl1.DataSource = ds.Tables("SampleStorage")
    End Sub
#End Region

#Region "加载"
    
    Sub Loadsampleorders()
        Dim SSList As New List(Of SampleStorageInfo)
        SSList = sscon.SampleStorage_GetList(SSID, Nothing, Nothing, Nothing, Nothing)
        If SSList.Count <= 0 Then
            Exit Sub
        End If
        txtD_ID.EditValue = SSList(0).D_ID
        txtSS_ShelveID.Text = SSList(0).SS_ShelveID
        txtSS_StorageLocation.Text = SSList(0).SS_StorageLocation
        txtPK_Code_ID.Text = SSList(0).SO_ID
        txtCreateuserID.Text = SSList(0).CreateUserID
        txtRemark.Text = SSList(0).Remark
    End Sub

    Private Sub frmSampleStorageAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim pclist As New List(Of LFERP.Library.ProductionController.ProductionFieldControlInfo)
        Dim pminfo As New LFERP.Library.ProductionController.ProductionFieldControlInfo
        Dim fc As New LFERP.Library.ProductionController.ProductionFieldControl
        pclist = fc.ProductionFieldControl_GetList(InUserID, Nothing)

        Me.txtD_ID.Properties.DataSource = pclist
        Me.txtD_ID.Properties.DisplayMember = "DepName"
        Me.txtD_ID.Properties.ValueMember = "ControlDep"

        '載入訂單編號
        Dim mtd As New SamplePaceControler
        txtPK_Code_ID.Properties.DisplayMember = "PK_Code_ID"
        txtPK_Code_ID.Properties.ValueMember = "SE_ID"
        txtPK_Code_ID.Properties.DataSource = sscon.SampleStorageA_GetList(DID)

        Dim spqInfo As New SamplePaceQueryInfo
        spqInfo.Code_ID = "All"
        spqList.Insert(0, spqInfo)
        Select Case EditItem
            Case EditEnumType.ADD
                Me.lblTitle.Text = Me.Text + EditEnumValue(EditEnumType.ADD)
                xtpCheck.PageVisible = False
                xtpCheck.PageEnabled = False
                txtCreateuserID.Text = InUserID
                Me.txtD_ID.EditValue = DID
                Me.txtD_ID.Enabled = False
                'Case EditEnumType.EDIT
                '    Loadsampleorders()
                '    Me.lblTitle.Text = Me.Text + EditEnumValue(EditEnumType.EDIT)
                '    xtpCheck.PageVisible = False
                '    xtpCheck.PageEnabled = False
                'Case EditEnumType.CHECK
                '    Loadsampleorders()
                '    GroupBox1.Enabled = False
                '    Me.lblTitle.Text = Me.Text + EditEnumValue(EditEnumType.CHECK)
                'Case EditEnumType.VIEW
                '    Loadsampleorders()
                '    GroupBox1.Enabled = False
                '    xtpCheck.PageVisible = False
                '    xtpCheck.PageEnabled = False

                'Me.lblTitle.Text = Me.Text + EditEnumValue(EditEnumType.VIEW)
        End Select
    End Sub
#End Region

#Region "条码键入事件"
    Private Sub txtM_Code_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtM_Code.KeyUp
        If e.KeyCode = Keys.Enter Then
            '1.条码重复
            Dim strM_Code As String
            Dim i As Integer
            strM_Code = Trim(UCase(Me.txtM_Code.Text))
            For i = 0 To ds.Tables("SampleStorage").Rows.Count - 1
                If strM_Code = ds.Tables("SampleStorage").Rows(i)("Code_ID") Then
                    txtM_Code.Text = String.Empty
                    txtM_Code.Focus()
                    lblCode.Text = "条码重复"
                    Exit Sub
                End If
            Next

            Dim OutSO_ID As String = String.Empty
            Dim OutPM_M_Code As String = String.Empty
            Dim SD_OutD_ID As String = String.Empty
            Dim SD_OutD_Name As String = String.Empty
            Dim OutSO_SampleID As String = String.Empty
            Dim SD_OutPS_NO As String = String.Empty
            Dim SD_OutPS_Name As String = String.Empty

            Dim scclist As New List(Of SampleCollectionInfo)
            scclist = Sccon.SampleCollection_Getlist(Nothing, strM_Code, Nothing, Nothing, Nothing, Nothing, False, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            If scclist.Count > 0 Then
                '2.采集表部门不存在此条码"-------------------------
                If scclist(0).D_ID <> txtD_ID.EditValue Then
                    txtM_Code.Text = String.Empty
                    txtM_Code.Focus()
                    lblCode.Text = "采集表部门不存在此条码"
                    Exit Sub
                End If

                '3.条码状态是否为在产
                If scclist(0).StatusType <> "Z" And scclist(0).StatusType <> "M" Then
                    txtM_Code.Text = String.Empty
                    txtM_Code.Focus()
                    lblCode.Text = "采集表条码状态不是在产,完工不能放入货架！"
                    Exit Sub
                End If
            Else
                txtM_Code.Text = String.Empty
                txtM_Code.Focus()
                lblCode.Text = "采集表不存在此条码"
                Exit Sub
            End If

            '3.插入临时表
            Dim row As DataRow
            row = ds.Tables("SampleStorage").NewRow
            row("Code_ID") = strM_Code
            row("SE_ID") = String.Empty
            row("ShelveID") = String.Empty
            row("Qty") = 1
            row("StorageLocation") = String.Empty
            ds.Tables("SampleStorage").Rows.Add(row)

            Me.txtM_Code.Text = String.Empty
            Me.lblCode.Text = String.Empty
        End If
    End Sub
#End Region

#Region "按钮功能"
    '取消按钮
    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub
    '保存按钮
    Private Sub Savebutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Savebutton.Click
        Dim ssInfo As New SampleStorageInfo
        Dim Type As String = String.Empty
        Select Case EditItem
            Case EditEnumType.ADD
                Type = "Add"
                SaveAdd(Type)
                'Case EditEnumType.EDIT
                '    Type = "Edit"
                '    SaveEdit(Type)
                'Case EditEnumType.CHECK
                '    Type = "Check"
                '    SaveCheck(Type)
        End Select

        If result = True Then
            MsgBox("保存成功！", 60, "提示")
            Me.Close()
        End If
    End Sub
#End Region

#Region "保存事件"
    '日志表保存
    Private Sub SaveLog(ByVal ssinfo As SampleStorageInfo, ByVal Type As String)
        Dim sslInfo As New SampleStorageLogInfo
        sslInfo.Code_ID = ssinfo.Code_ID
        sslInfo.CreateUserID = InUserID
        sslInfo.D_ID = ssinfo.D_ID
        sslInfo.OperateType = Type
        sslInfo.SS_ShelveID = ssinfo.SS_ShelveID
        sslInfo.SO_ID = ssinfo.SO_ID
        sslInfo.SS_StorageLocation = ssinfo.SS_StorageLocation
        sslInfo.SO_SampleID = txtSampleID.Text
        If sslcon.SampleStorageLog_Add(sslInfo) = False Then
            MsgBox("保存日志失败！", 60, "提示")
            Exit Sub
        End If
    End Sub
    '添加事件
    Private Sub SaveAdd(ByVal Type As String)
        If CheckDateEmpty() = True Then
            For i As Int32 = 0 To ds.Tables("SampleStorage").Rows.Count - 1
                Dim StrCode_ID As String = ds.Tables("SampleStorage").Rows(i)("Code_ID")
                Dim m_list As New List(Of SampleStorageInfo)
                '1.判断条码是否存在
                m_list = sscon.SampleStorage_GetList(Nothing, Nothing, StrCode_ID, Nothing, Nothing)
                '2.如果此条码不存在，则添加
                If m_list.Count <= 0 Then
                    Dim ssinfo As New SampleStorageInfo
                    ssinfo.CreateUserID = InUserID
                    ssinfo.D_ID = txtD_ID.EditValue
                    ssinfo.Remark = txtRemark.Text
                    ssinfo.SS_ShelveID = ds.Tables("SampleStorage").Rows(i)("ShelveID")
                    ssinfo.Code_ID = StrCode_ID
                    ssinfo.SS_StorageLocation = ds.Tables("SampleStorage").Rows(i)("StorageLocation")
                    ssinfo.Qty = ds.Tables("SampleStorage").Rows(i)("Qty")
                    result = sscon.SampleStorage_Add(ssinfo)
                    SaveLog(ssinfo, "Add")
                Else
                    '3.如果此条码存在，则修改
                    Dim ssinfo As New SampleStorageInfo
                    ssinfo.AutoID = m_list(0).AutoID
                    ssinfo.ModifyUserID = InUserID
                    ssinfo.D_ID = txtD_ID.EditValue
                    ssinfo.Code_ID = StrCode_ID
                    ssinfo.Remark = txtRemark.Text
                    ssinfo.SS_ShelveID = ds.Tables("SampleStorage").Rows(i)("ShelveID")
                    ssinfo.SS_StorageLocation = ds.Tables("SampleStorage").Rows(i)("StorageLocation")
                    ssinfo.Qty = ds.Tables("SampleStorage").Rows(i)("Qty")
                    result = sscon.SampleStorage_Update(ssinfo)
                    SaveLog(ssinfo, "Edit")
                End If

            Next
        End If
    End Sub
#End Region

#Region "赋值事件"
    '单号赋值
    Private Sub GridView7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtPM_M_Code.Text = GridView7.GetFocusedRowCellValue("PM_M_Code")
        txtSO_ID.Text = GridView7.GetFocusedRowCellValue("SO_ID")
        txtSampleID.Text = GridView7.GetFocusedRowCellValue("SO_SampleID")
    End Sub


    '单号添加事件
    Private Sub txtSE_ID_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPK_Code_ID.EditValueChanged
        CreateTable()
        ds.Tables("SampleStorage").Rows.Clear()
        Dim con As New SampleStorageController
        Dim dt As New DataTable
        If txtPK_Code_ID.EditValue = String.Empty Then
            Exit Sub
        End If
        Dim pklistA As New List(Of SamplePackingInfo)
        pklistA = pkcom.SamplePacking_GetList(Nothing, Nothing, Nothing, txtPK_Code_ID.Text, Nothing, Nothing, Nothing, Nothing)
        If pklistA.Count > 0 Then

            Dim pklist As New List(Of SamplePackingInfo)
            pklist = pkcom.SamplePackingSub_GetList(Nothing, pklistA(0).PK_ID, Nothing, Nothing)
            If pklist.Count <= 0 Then
                Exit Sub
            End If
            Dim i As Integer
            For i = 0 To pklist.Count - 1
                Dim scclist As New List(Of SampleCollectionInfo)
                scclist = Sccon.SampleCollection_Getlist(Nothing, pklist(i).Code_ID, Nothing, Nothing, Nothing, Nothing, False, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                If scclist.Count > 0 Then
                    '2.采集表部门不存在此条码"-------------------------
                    If scclist(0).D_ID <> txtD_ID.EditValue Then
                        txtM_Code.Text = String.Empty
                        txtM_Code.Focus()
                        lblCode.Text = "采集表部门不存在此条码"
                        ds.Tables("SampleStorage").Rows.Clear()
                        Exit Sub
                    End If

                    '3.条码状态是否为在产
                    If scclist(0).StatusType <> "Z" And scclist(0).StatusType <> "M" Then
                        txtM_Code.Text = String.Empty
                        txtM_Code.Focus()
                        lblCode.Text = "采集表条码状态不是在产,完工不能放入货架！"
                        ds.Tables("SampleStorage").Rows.Clear()
                        Exit Sub
                    End If
                Else
                    txtM_Code.Text = String.Empty
                    txtM_Code.Focus()
                    lblCode.Text = "采集表不存在此条码"
                    ds.Tables("SampleStorage").Rows.Clear()
                    Exit Sub
                End If

                Dim row As DataRow
                row = ds.Tables("SampleStorage").NewRow
                row("AutoID") = pklist(i).AutoID
                row("Code_ID") = pklist(i).Code_ID
                row("Qty") = pklist(i).Qty
                row("ShelveID") = txtSS_ShelveID.Text
                row("StorageLocation") = txtSS_StorageLocation.Text
                ds.Tables("SampleStorage").Rows.Add(row)
            Next
        End If

    End Sub

    '货架号值统一改变
    Private Sub txtSS_ShelveID_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSS_ShelveID.EditValueChanged
        Dim i As Integer
        For i = 0 To ds.Tables("SampleStorage").Rows.Count - 1
            ds.Tables("SampleStorage").Rows(i)("ShelveID") = txtSS_ShelveID.Text
        Next
    End Sub
    '存储位置统一改变
    Private Sub txtSS_StorageLocation_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSS_StorageLocation.EditValueChanged
        Dim i As Integer
        For i = 0 To ds.Tables("SampleStorage").Rows.Count - 1
            ds.Tables("SampleStorage").Rows(i)("StorageLocation") = txtSS_StorageLocation.EditValue
        Next
    End Sub
#End Region

#Region "其他事件"

    '删除菜单
    Private Sub tsmDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDelete.Click
        Dim m_int As Int16 = GridView2.FocusedRowHandle
        If MsgBox("确定要删除此条码吗？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ds.Tables("SampleStorage").Rows.RemoveAt(m_int)
        End If
    End Sub

    '检测空值
    Function CheckDateEmpty() As Boolean
        '--------主檔
        CheckDateEmpty = True
        If txtSS_ShelveID.Text = String.Empty Then
            CheckDateEmpty = False
            MsgBox("您沒有输入货架编号！", MsgBoxStyle.OkOnly, "提示")
            txtSS_ShelveID.Focus()
            Exit Function
        End If
        If txtSS_StorageLocation.Text = String.Empty Then
            CheckDateEmpty = False
            MsgBox("您沒有输入区域位置！", MsgBoxStyle.OkOnly, "提示")
            txtSS_StorageLocation.Focus()
            Exit Function
        End If

        'If txtPK_Code_ID.Text = String.Empty Then
        '    CheckDateEmpty = False
        '    MsgBox("您沒有输入单号！", MsgBoxStyle.OkOnly, "提示")
        '    txtPK_Code_ID.Focus()
        '    Exit Function
        'End If

        For i As Int32 = 0 To ds.Tables("SampleStorage").Rows.Count - 1
            If ds.Tables("SampleStorage").Rows(i)("Code_ID") = String.Empty Then
                CheckDateEmpty = False
                MsgBox("条码不能为空！", MsgBoxStyle.OkOnly, "提示")
                GridView2.Focus()
                GridView2.FocusedRowHandle = i
                Exit Function
            End If
            If ds.Tables("SampleStorage").Rows(i)("ShelveID") = String.Empty Then

                CheckDateEmpty = False
                MsgBox("货架不能为空！", MsgBoxStyle.OkOnly, "提示")
                GridView2.Focus()
                GridView2.FocusedRowHandle = i
                Exit Function

            End If
            If ds.Tables("SampleStorage").Rows(i)("StorageLocation") = String.Empty Then
                CheckDateEmpty = False
                MsgBox("区域不能为空！", MsgBoxStyle.OkOnly, "提示")
                GridView2.Focus()
                GridView2.FocusedRowHandle = i
                Exit Function

            End If
        Next
    End Function
#End Region

End Class