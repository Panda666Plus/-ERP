Imports LFERP.Library.MrpManager.MrpPurchaseRecord
Public Class frmMrpPurchaseRecord
    Dim ds As New DataSet
    Private _Type As String
    Dim mrpRecordCon As New MrpPurchaseRecordController
    Dim mrpRecordList As New List(Of MrpPurchaseRecordInfo)
    Dim mrpRecordInfo As New MrpPurchaseRecordInfo
    Dim mrpeRecordCon As New MrpPurchaseRecordEntryController
    Dim mrpeRecordList As New List(Of MrpPurchaseRecordEntryInfo)
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property
    Private _MrpPurchaseID As String
    Public Property MrpPurchaseID() As String
        Get
            Return _MrpPurchaseID
        End Get
        Set(ByVal value As String)
            _MrpPurchaseID = value
        End Set
    End Property
    Private Sub frmMrpPurchaseRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateTable()
        LoadTable()
    
        Select Case _Type
            Case "Add"
                Lbl_Title.Text = "MRP請購記錄—新建"
                xtpCheck.PageVisible = False
                txt_MP_CreateUserName.Text = InUserID
                txt_MrpPurchID.Text = "PU2013110001"
            Case "Edit"
                mrpeRecordList = mrpeRecordCon.MrpPurchaseRecordEntry_GetList(MrpPurchaseID)
                Lbl_Title.Text = "MRP請購記錄—修改"
                mrpRecordList = mrpRecordCon.MrpPurchaseRecord_GetList(MrpPurchaseID)
                xtpCheck.PageVisible = False
                txt_MP_CreateUserName.Text = mrpRecordList(0).MPP_CreateUserID
                txt_MRP_ID.Text = mrpRecordList(0).MRP_ID
                txt_MrpPurchID.Text = mrpRecordList(0).MrpPurchaseID

            Case "Check"
                mrpeRecordList = mrpeRecordCon.MrpPurchaseRecordEntry_GetList(MrpPurchaseID)
                mrpRecordList = mrpRecordCon.MrpPurchaseRecord_GetList(MrpPurchaseID)
                Lbl_Title.Text = "MRP請購記錄—審核"
                xtpCheck.PageVisible = True
                xtcTable.SelectedTabPageIndex = 0
                txt_MP_CreateUserName.Text = mrpRecordList(0).MPP_CreateUserID
                txt_MRP_ID.Text = mrpRecordList(0).MRP_ID
                txt_MrpPurchID.Text = mrpRecordList(0).MrpPurchaseID
                GroupBox1.Enabled = False
                Grid1.Enabled = False
                chkCheckBit.Checked = mrpRecordList(0).CheckBit
                txtCheckRemark.Text = mrpRecordList(0).CheckRemark
                lblCheckDate.Text = Format(Now, "yyyy/MM/dd")
                lblCheckUserID.Text = InUserID

            Case "View"
                mrpeRecordList = mrpeRecordCon.MrpPurchaseRecordEntry_GetList(MrpPurchaseID)

                mrpRecordList = mrpRecordCon.MrpPurchaseRecord_GetList(MrpPurchaseID)
                Lbl_Title.Text = "MRP請購記錄—查看"
                xtpCheck.PageVisible = False
                GroupBox1.Enabled = False
                Grid1.Enabled = False
                txt_MP_CreateUserName.Text = mrpRecordList(0).MPP_CreateUserID
                txt_MRP_ID.Text = mrpRecordList(0).MRP_ID
                txt_MrpPurchID.Text = mrpRecordList(0).MrpPurchaseID
        End Select
    End Sub
    Private Sub CreateTable()
        ds.Tables.Clear()
        '創建臨時子表
        With ds.Tables.Add("MrpPurchaseRecordEntry")
            .Columns.Add("MRP_ID", GetType(String))
            .Columns.Add("M_Code", GetType(String))
            .Columns.Add("MPI_NeedQty", GetType(Double))
            .Columns.Add("MPI_CreateUserID", GetType(String))
            .Columns.Add("MPI_CreateDate", GetType(Date))
            .Columns.Add("MPI_ModifyUserID", GetType(String))
            .Columns.Add("MPI_ModifyDate", GetType(Date))
            .Columns.Add("AutoID", GetType(Decimal))
            .Columns.Add("MrpPurchaseID", GetType(String))
            .Columns.Add("MP_CreateUserName", GetType(String))
            .Columns.Add("MP_ModifyUserName", GetType(String))
        End With

        Grid1.DataSource = ds.Tables("MrpPurchaseRecordEntry")
        '創建臨時刪除表
        With ds.Tables.Add("DelTable")
            .Columns.Add("AutoID", GetType(Decimal))
        End With
    End Sub
    Private Sub LoadTable()
        ds.Tables("MrpPurchaseRecordEntry").Clear()
        If MrpPurchaseID <> String.Empty Then
            mrpeRecordList = mrpeRecordCon.MrpPurchaseRecordEntry_GetList(MrpPurchaseID)
            If mrpRecordList.Count > 0 Then
                mrpRecordInfo = mrpRecordList(0)
            End If
        End If
        If mrpeRecordList.Count = 0 Then
            Exit Sub
        End If
        Dim i As Integer
        For i = 0 To mrpeRecordList.Count - 1
            Dim row As DataRow
            row = ds.Tables("MrpPurchaseRecordEntry").NewRow
            row("AutoID") = mrpeRecordList(i).AutoID
            row("M_Code") = mrpeRecordList(i).M_Code
            row("MPI_CreateDate") = mrpeRecordList(i).MPI_CreateDate
            row("MPI_CreateUserID") = mrpeRecordList(i).MPI_CreateUserID
            row("MP_CreateUserName") = mrpeRecordList(i).MP_CreateUserName
            row("MPI_ModifyDate") = mrpeRecordList(i).MPI_ModifyDate
            row("MPI_ModifyUserID") = mrpeRecordList(i).MPI_ModifyUserID
            row("MP_ModifyUserName") = mrpeRecordList(i).MP_ModifyUserName
            row("MPI_NeedQty") = mrpeRecordList(i).MPI_NeedQty
            row("MRP_ID") = mrpeRecordList(i).MRP_ID
            row("MrpPurchaseID") = mrpeRecordList(i).MrpPurchaseID
            ds.Tables("MrpPurchaseRecordEntry").Rows.Add(row)
        Next
    End Sub
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Select Case Type
            Case "Add"
                Savedate()
            Case "Edit"
                Savedate()
            Case "Check"
                Check()
        End Select
    End Sub

    '保存按鈕功能—添加與修改
    Private Sub Savedate()
        '主表數據
        Dim MrpInfo As New MrpPurchaseRecordInfo
        Dim MrpCon As New MrpPurchaseRecordController
        Dim mrpecom As New MrpPurchaseRecordEntryController

        MrpInfo.MRP_ID = txt_MRP_ID.Text
        MrpInfo.MrpPurchaseID = txt_MrpPurchID.Text
        If _Type = "Add" Then
            MrpInfo.CheckBit = False
            MrpInfo.MPP_CreateUserID = InUserID

            'Str = "KB4000"
            'If Str <> txt_MrpPurchID.Text Then
            '    MsgBox(txt_MrpPurchID.Text & " 订单编号已经被占用，订单编号將变更為" + Str, MsgBoxStyle.OkOnly, "提示")
            '    MrpInfo.MrpPurchaseID = Str
            'End If

            MrpInfo.MrpPurchaseID = txt_MrpPurchID.Text
            If CheckDateEmpty() = False Then
                Exit Sub
            End If

            If MrpCon.MrpPurchaseRecord_Add(MrpInfo) = False Then
                Exit Sub
            End If
            For i As Integer = 0 To ds.Tables("MrpPurchaseRecordEntry").Rows.Count - 1
                With ds.Tables("MrpPurchaseRecordEntry")
                    Dim mrpeInfo As New MrpPurchaseRecordEntryInfo
                    mrpeInfo.M_Code = .Rows(i)("M_Code").ToString
                    mrpeInfo.MPI_CreateUserID = .Rows(i)("MPI_CreateUserID").ToString
                    mrpeInfo.MPI_NeedQty = .Rows(i)("MPI_NeedQty").ToString
                    mrpeInfo.MRP_ID = .Rows(i)("MRP_ID").ToString
                    mrpeInfo.MrpPurchaseID = .Rows(i)("MrpPurchaseID").ToString
                    mrpecom.MrpPurchaseRecordEntry_Add(mrpeInfo)
                End With
            Next
            MsgBox("保存成功！")
            Me.Close()
        End If

        If _Type = "Edit" Then
            mrpRecordList = mrpRecordCon.MrpPurchaseRecord_GetList(MrpPurchaseID)
            Dim objectInfo As New MrpPurchaseRecordInfo
            objectInfo.MPP_ModifyUserID = InUserID
            objectInfo.MRP_ID = txt_MRP_ID.Text
            objectInfo.MrpPurchaseID = txt_MrpPurchID.Text
            objectInfo.AutoID = mrpRecordList(0).AutoID
            If CheckDateEmpty() = False Then
                Exit Sub
            End If
            If MrpCon.MrpPurchaseRecord_Update(objectInfo) = False Then
                Exit Sub
            End If
            For i As Integer = 0 To GridView.RowCount - 1

                Dim mrpeInfo As New MrpPurchaseRecordEntryInfo
                mrpeInfo.M_Code = GridView.GetRowCellValue(i, "M_Code").ToString

                If GridView.GetRowCellValue(i, "AutoID").ToString = "" Then
                    mrpeInfo.AutoID = 0
                Else
                    mrpeInfo.AutoID = GridView.GetRowCellValue(i, "AutoID").ToString

                End If
               
                mrpeInfo.MPI_ModifyDate = Now
                mrpeInfo.MPI_ModifyUserID = InUserID
                If GridView.GetRowCellValue(i, "MPI_NeedQty").ToString = "" Then
                    mrpeInfo.MPI_NeedQty = 0
                Else
                    mrpeInfo.MPI_NeedQty = GridView.GetRowCellValue(i, "MPI_NeedQty").ToString

                End If
                mrpeInfo.MRP_ID = GridView.GetRowCellValue(i, "MRP_ID").ToString
                mrpeInfo.MrpPurchaseID = GridView.GetRowCellValue(i, "MrpPurchaseID").ToString

                If mrpeInfo.AutoID = 0 Then
                    mrpecom.MrpPurchaseRecordEntry_Add(mrpeInfo)
                Else

                    mrpecom.MrpPurchaseRecordEntry_Update(mrpeInfo)
                End If

            Next
            For i As Integer = 0 To ds.Tables("DelTable").Rows.Count - 1
                If ds.Tables("DelTable").Rows.Count = 0 Then
                    Exit For
                End If
                If IsDBNull(ds.Tables("DelTable").Rows(i)("AutoID")) = False Then
                    mrpecom.MrpPurchaseRecordEntry_Delete(Nothing, ds.Tables("DelTable").Rows(i)("AutoID"))
                End If

            Next
            MsgBox("保存成功！")
            Me.Close()
        End If
    End Sub
    '保存按鈕功能—審核
    Private Sub Check()
        Dim MrpCon As New MrpPurchaseRecordController
        MrpCon.MrpPurchaseRecord_Check(Nothing, txt_MrpPurchID.Text, chkCheckBit.Checked, txtCheckRemark.Text, lblCheckUserID.Text, Now)
        Me.Close()
    End Sub
    Private Function CheckDateEmpty() As Boolean
        Return True
    End Function
    Private Sub tsmNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmNew.Click
        Dim row As DataRow = ds.Tables("MrpPurchaseRecordEntry").NewRow
        row("MRP_ID") = txt_MRP_ID.Text
        row("MrpPurchaseID") = txt_MrpPurchID.Text
        ds.Tables("MrpPurchaseRecordEntry").Rows.Add(row)
        GridView.FocusedRowHandle = GridView.RowCount - 1
    End Sub
    Private Sub tsmDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDelete.Click
        If GridView.RowCount <= 0 Then
            Exit Sub
        End If
        Dim row As DataRow
        row = ds.Tables("DelTable").NewRow
        row("AutoID") = GridView.GetFocusedRowCellValue("AutoID")
        ds.Tables("DelTable").Rows.Add(row)
        GridView.DeleteRow(GridView.FocusedRowHandle())
        GridView.SelectRow(GridView.RowCount - 1)
        GridView.FocusedRowHandle = GridView.RowCount - 1
    End Sub

    Private Sub txt_MRP_ID_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_MRP_ID.EditValueChanged
        For i As Int16 = 0 To GridView.RowCount - 1
            GridView.SetRowCellValue(i, "MRP_ID", txt_MRP_ID.Text)
        Next
    End Sub
End Class