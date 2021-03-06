Imports LFERP.Library.ProductionField
Imports LFERP.SystemManager
Imports LFERP.DataSetting
Imports LFERP.Library.ProductionController
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core



Public Class frmProductionFieldCodeMain

    Dim pfc As New Library.ProductionField.ProductionFieldControl
    Dim strDPT As String
    Dim ds As New DataSet
    Dim upc As LFERP.Library.ProductionController.ProductionFieldControl
    Dim upi As New List(Of UserPowerInfo)
    Dim upcc As New UserPowerControl

    Dim smChaiFenZuhe As Boolean = False ''查詢用戶是否有組合,拆分權限

    Private Sub frmProductionFieldCodeMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        upi = upcc.UserPower_GetList(InUserID, Nothing, Nothing, Nothing)
        If upi.Count = 0 Then Exit Sub
        ComboPro_Type.EditValue = upi(0).UserType
        '-----------------------------------------------

        Dim fc As New LFERP.Library.ProductionController.ProductionFieldControl
        GridControl2.DataSource = fc.ProductionFieldControl_GetList(InUserID, Nothing)

        GridView2.Focus()
        If GridView2.RowCount = 0 Then Exit Sub
        strDPT = GridView2.GetFocusedRowCellValue("ControlDep").ToString()
        If strDPT = "F101" Then
            If InUserID = "第一生產倉" Or InUserID = "第二生產倉" Or InUserID = "第三生產倉" Then
                MenuCodeInAdd.Visible = False

                smDaHuo.Visible = True
                smChuHuo.Visible = False
                smZuhe.Visible = False
                smChaiFen.Visible = False
                smFanXiu.Visible = False
                smRePairOut.Visible = False
                smWaiFa.Visible = False
                smSunHuai.Visible = False
                smDiuShi.Visible = False
                smBuLiang.Visible = False
                smLiuBan.Visible = False
                smCunHuo.Visible = False
                smCunCang.Visible = False
                smChengPin.Visible = False   '送成品倉
            Else
                MenuCodeInAdd.Visible = False

                smDaHuo.Visible = False
                smChuHuo.Visible = False
                smZuhe.Visible = False
                smChaiFen.Visible = False
                smFanXiu.Visible = True
                smRePairOut.Visible = False
                smWaiFa.Visible = True
                smSunHuai.Visible = False
                smDiuShi.Visible = False
                smBuLiang.Visible = False
                smLiuBan.Visible = False
                smCunHuo.Visible = False
                smCunCang.Visible = False
                smChengPin.Visible = False   '送成品倉
            End If
            'FP_OutType.Visible = True
            'chkOutProcess.Visible = True
            'chkBlocProcess.Visible = True
        Else
            'FP_OutType.Visible = False
            'chkOutProcess.Visible = False
            'chkBlocProcess.Visible = False
            MenuCodeInAdd.Visible = True
            ' smJiaCun.Visible = False
            smJiaCun.Visible = True
            smDaHuo.Visible = True
            smChuHuo.Visible = True
            smZuhe.Visible = True
            smChaiFen.Visible = True
            smFanXiu.Visible = True
            smRePairOut.Visible = True
            smWaiFa.Visible = True
            smSunHuai.Visible = True
            smDiuShi.Visible = True
            smBuLiang.Visible = True
            smLiuBan.Visible = True
            smCunHuo.Visible = True
            smCunCang.Visible = True

            If InUserID = "第一裝配" Or InUserID = "第二裝配" Or InUserID = "第三裝配" Then
                smChengPin.Visible = True   '送成品倉
            Else
                smChengPin.Visible = False   '送成品倉
            End If

            ' If CInt(InStr(InUserID, "燒焊")) >= 1 Or CInt(InStr(InUserID, "組裝")) >= 1 Then '2012-6-2
            If smChaiFenZuhe = True Then
                smChaiFen.Visible = True
                smZuhe.Visible = True
            Else
                smChaiFen.Visible = False
                smZuhe.Visible = False
            End If

        End If

        twWare.ExpandAll()
        twWare.Select()
        twWare.SelectedNode.Name = "Node4"
        UserPower()
    End Sub

    Sub UserPower()  '設置當權模塊權限

        Dim pmws As New PermissionModuleWarrantSubController
        Dim pmwiL As List(Of PermissionModuleWarrantSubInfo)

        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880401")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then MenuCodeInAdd.Enabled = True

        End If

        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880402")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then MenuCodeOutAdd.Enabled = True
        End If

        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880403")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then MenuCodeEdit.Enabled = True
        End If
        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880404")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then MenuCodeDel.Enabled = True
        End If
        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880405")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then MenuCodeInCheck.Enabled = True
        End If
        '-------------------------------------------------------------------------
        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880406") ' 開料權限
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then smKaiLiao.Enabled = True
        End If
        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880407")  '加存權限
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then smJiaCun.Enabled = True
        End If
        '-------------------------------------------------------------------------  刷卡為880408
        'DeltialMenuItem.Enabled = False
        'pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880409")  '加收發明細權限權限
        'If pmwiL.Count > 0 Then
        '    If pmwiL.Item(0).PMWS_Value = "是" Then DeltialMenuItem.Enabled = True
        'End If

        '2013-8-20---------
        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880410")  '生產倉發料
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then ToolWareFaLiao.Visible = True
        End If

        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880411")  '外發送裝配
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then ToolWaiFaASS.Visible = True
        End If

        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880412")  '裝配不良
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then ToolASSBuNiang.Visible = True
        End If


        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880415")  '可選加工類型
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then
                ComboPro_Type.Enabled = True
            End If

        End If

        ''顯示組合,折分功能
        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "880417")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then
                smChaiFenZuhe = True
            End If

        End If

        '


    End Sub

    '@ 顯示數據
    '此過程被以下過程調用
    '@ 2012/2/21 修改 只顯示當前7天內的記錄
    'twWare_AfterSelect()
    'MenuCodeRef_Click()
    Sub ShowData(ByVal CheckState As String, ByVal strFP_OutType As String)

        Dim strComboPro_Type As String = Nothing

        If ComboPro_Type.EditValue = "全部" Then
            strComboPro_Type = Nothing
        Else
            strComboPro_Type = ComboPro_Type.EditValue
        End If

        Select Case CheckState

            Case "未審核"
                If twWare.SelectedNode.Parent.Text = "收入項目" Then
                    Pro_NO.Caption = "收料工序"
                    Pro_NO1.Caption = "發料工序"
                    'Grid.DataSource = pfc.ProductionField_GetList(Nothing, Nothing, "收料", Nothing, strDPT, Nothing, Nothing, False, DateAdd(DateInterval.Day, -7, CDate(Format(Now, "yyyy/MM/dd"))), ">=", "2")
                    ' Grid.DataSource = pfc.ProductionField_GetList(Nothing, Nothing, "收料", Nothing, strDPT, Nothing, Nothing, False, Nothing, Nothing, "2", strFP_OutType, Nothing)
                    Grid.DataSource = pfc.ProductionField_GetList3(Nothing, Nothing, "收料", Nothing, strDPT, Nothing, Nothing, False, Nothing, Nothing, "2", strFP_OutType, Nothing, strComboPro_Type, Nothing)

                End If
                If twWare.SelectedNode.Parent.Text = "發出項目" Then
                    'Grid.DataSource = pfc.ProductionField_GetList(Nothing, Nothing, "發料", Nothing, strDPT, Nothing, Nothing, False, DateAdd(DateInterval.Day, -7, CDate(Format(Now, "yyyy/MM/dd"))), ">=", "2")
                    'Grid.DataSource = pfc.ProductionField_GetList(Nothing, Nothing, "發料", Nothing, strDPT, Nothing, Nothing, False, Nothing, Nothing, "2", strFP_OutType, Nothing)
                    Grid.DataSource = pfc.ProductionField_GetList3(Nothing, Nothing, "發料", Nothing, strDPT, Nothing, Nothing, False, Nothing, Nothing, "2", strFP_OutType, Nothing, strComboPro_Type, Nothing)
                    Pro_NO1.Caption = "收料工序"
                    Pro_NO.Caption = "發料工序"
                End If

            Case "已審核"
                If twWare.SelectedNode.Parent.Text = "收入項目" Then
                    Pro_NO.Caption = "收料工序"
                    Pro_NO1.Caption = "發料工序"
                    'Grid.DataSource = pfc.ProductionField_GetList(Nothing, Nothing, "收料", Nothing, strDPT, Nothing, Nothing, True, DateAdd(DateInterval.Day, -7, CDate(Format(Now, "yyyy/MM/dd"))), ">=", "2", strFP_OutType, Nothing)
                    Grid.DataSource = pfc.ProductionField_GetList3(Nothing, Nothing, "收料", Nothing, strDPT, Nothing, Nothing, True, DateAdd(DateInterval.Day, -7, CDate(Format(Now, "yyyy/MM/dd"))), ">=", "2", strFP_OutType, Nothing, strComboPro_Type, Nothing)

                End If
                If twWare.SelectedNode.Parent.Text = "發出項目" Then
                    'Grid.DataSource = pfc.ProductionField_GetList(Nothing, Nothing, "發料", Nothing, strDPT, Nothing, Nothing, True, DateAdd(DateInterval.Day, -7, CDate(Format(Now, "yyyy/MM/dd"))), ">=", "2", strFP_OutType, Nothing)
                    Grid.DataSource = pfc.ProductionField_GetList3(Nothing, Nothing, "發料", Nothing, strDPT, Nothing, Nothing, True, DateAdd(DateInterval.Day, -7, CDate(Format(Now, "yyyy/MM/dd"))), ">=", "2", strFP_OutType, Nothing, strComboPro_Type, Nothing)
                    Pro_NO1.Caption = "收料工序"
                    Pro_NO.Caption = "發料工序"
                End If

        End Select
    End Sub

    '左側樹狀---顯示右側數據
    '@ 2012/1/5改爲調用過程實現，調用 ShowData() 過程
    Private Sub twWare_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles twWare.AfterSelect
        If e.Node.Level = 1 Then
            ShowData(Mid(twWare.SelectedNode.Text, 1, 3), Nothing)
        End If

    End Sub

    Private Sub MenuCodeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCodeEdit.Click
        On Error Resume Next

        If GridView1.RowCount = 0 Then Exit Sub

        Dim pfi1 As List(Of ProductionFieldInfo)
        Dim pfi As List(Of ProductionFieldInfo)

        Dim strType As String
        strType = GridView1.GetFocusedRowCellValue("FP_Type")

        pfi1 = pfc.ProductionField_GetList(GridView1.GetFocusedRowCellValue("FP_NO").ToString, Nothing, strType, Nothing, Nothing, Nothing, Nothing, True, Nothing, Nothing, "1", Nothing, Nothing)

        If pfi1.Count <> 0 Then
            MsgBox("此操作已被確認,不允許更改!")
            Exit Sub
        End If

        pfi = pfc.ProductionField_GetList(GridView1.GetFocusedRowCellValue("FP_NO").ToString, Nothing, strType, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, "1", Nothing, Nothing)
        If pfi.Count = 0 Then Exit Sub

        If pfi(0).FP_Detail = "PT03" Or pfi(0).FP_Detail = "PT04" Then '開料對應PT03,加存對應PT04

            Edit = True
            Dim fr As frmProductionFieldCodeIn
            For Each fr In MDIMain.MdiChildren
                If TypeOf fr Is frmProductionFieldCodeIn Then
                    fr.Activate()
                    Exit Sub
                End If
            Next
            fr = New frmProductionFieldCodeIn
            tempValue = "CodeIn"
            tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.Show()

        ElseIf pfi(0).FP_Detail = "PT01" Or pfi(0).FP_Detail = "PT02" Or pfi(0).FP_Detail = "PT12" Or pfi(0).FP_Detail = "PT13" Or pfi(0).FP_Detail = "PT15" Or pfi(0).FP_Detail = "PT16" Or pfi(0).FP_Detail = "PT14" Then '大貨對應PT01,返修對應PT02

            If GridView1.GetFocusedRowCellValue("FP_Type").ToString <> "發料" Then
                MsgBox("您隻能對'發料'性質的記錄進行修改刪除操作！")
                Exit Sub
            Else
                Edit = True
                Dim fr As frmProductionFieldCode
                For Each fr In MDIMain.MdiChildren
                    If TypeOf fr Is frmProductionFieldCode Then
                        fr.Activate()
                        Exit Sub
                    End If
                Next
                fr = New frmProductionFieldCode
                tempValue = "CodeOut"
                tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString

                tempValue6 = twWare.SelectedNode.Parent.Text  '傳入當前選擇類型（收料/發料）

                fr.MdiParent = MDIMain
                fr.WindowState = FormWindowState.Maximized
                fr.Show()
            End If

        ElseIf pfi(0).FP_Detail = "PT18" Or pfi(0).FP_Detail = "PT19" Or pfi(0).FP_Detail = "PT20" Then '2013-8-20新增

            If GridView1.GetFocusedRowCellValue("FP_Type").ToString <> "發料" Then
                MsgBox("您隻能對'發料'性質的記錄進行修改刪除操作！")
                Exit Sub
            Else
                Dim fr As frmProductionFieldWare
                'For Each fr In Me.MdiChildren
                '    If TypeOf fr Is frmProductionFieldWare Then
                '        fr.Activate()
                '        Exit Sub
                '    End If
                'Next
                fr = New frmProductionFieldWare


                tempValue = "CodeOut"
                tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
                Edit = True
                tempValue6 = twWare.SelectedNode.Parent.Text  '傳入當前選擇類型（收料/發料）

                fr.MdiParent = MDIMain
                fr.WindowState = FormWindowState.Maximized
                fr.Show()
            End If

        Else

                If GridView1.GetFocusedRowCellValue("FP_Type").ToString <> "發料" Then
                    MsgBox("您隻能對'發料'性質的記錄進行修改刪除操作！")
                    Exit Sub
                Else
                    Edit = True
                    Dim fr As frmProductionFieldCodeOut
                    For Each fr In MDIMain.MdiChildren
                        If TypeOf fr Is frmProductionFieldCodeOut Then
                            fr.Activate()
                            Exit Sub
                        End If
                    Next
                    fr = New frmProductionFieldCodeOut
                    tempValue = "CodeHouse"
                    tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
                    fr.MdiParent = MDIMain
                    fr.WindowState = FormWindowState.Maximized
                    fr.Show()
                End If
            End If


    End Sub

    Private Sub MenuCodeDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCodeDel.Click
        On Error Resume Next
        If GridView1.RowCount = 0 Then Exit Sub

        Dim pfi1 As List(Of ProductionFieldInfo)
        pfi1 = pfc.ProductionField_GetList(GridView1.GetFocusedRowCellValue("FP_NO").ToString, Nothing, "收料", Nothing, Nothing, Nothing, True, Nothing, Nothing, Nothing, "1", Nothing, Nothing)
        If pfi1.Count <> 0 Then
            MsgBox("此操作已被確認,不允許刪除!")
            Exit Sub
        End If

        Dim pfi As List(Of ProductionFieldInfo)

        Dim strType As String
        strType = GridView1.GetFocusedRowCellValue("FP_Type").ToString

        pfi = pfc.ProductionField_GetList(GridView1.GetFocusedRowCellValue("FP_NO").ToString, Nothing, strType, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, "1", Nothing, Nothing)
        If pfi.Count = 0 Then Exit Sub

        If pfi(0).FP_Detail = "PT03" Or pfi(0).FP_Detail = "PT04" Then

            If MsgBox("你確定刪除物料收發單號為  '" & GridView1.GetFocusedRowCellValue("FP_NO").ToString & "'  的記錄嗎?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If pfc.ProductionField_Delete(GridView1.GetFocusedRowCellValue("FP_NO").ToString, Nothing) = True Then
                    MsgBox("刪除成功!")
                    '@ 2012/2/21 修改 只顯示當前7天內的記錄
                    Grid.DataSource = pfc.ProductionField_GetList(Nothing, Nothing, "發料", Nothing, pfi(0).FP_OutDep, Nothing, False, False, DateAdd(DateInterval.Day, -7, CDate(Format(Now, "yyyy/MM/dd"))), ">=", "2", Nothing, Nothing)
                Else
                    MsgBox("刪除失敗,請檢查原因!")
                    Exit Sub
                End If
            End If

        ElseIf pfi(0).FP_Detail = "PT01" Or pfi(0).FP_Detail = "PT02" Then
            If pfi(0).FP_Type <> "發料" Then
                MsgBox("您隻能對'發料'性質的記錄進行修改刪除操作！")
                Exit Sub
            End If

            If MsgBox("你確定刪除物料收發單號為  '" & GridView1.GetFocusedRowCellValue("FP_NO").ToString & "'  的記錄嗎?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If pfc.ProductionField_Delete(GridView1.GetFocusedRowCellValue("FP_NO").ToString, Nothing) = True Then
                    MsgBox("刪除成功!")
                    '@ 2012/2/21 修改 只顯示當前7天內的記錄
                    Grid.DataSource = pfc.ProductionField_GetList(Nothing, Nothing, "發料", Nothing, pfi(0).FP_OutDep, Nothing, False, False, DateAdd(DateInterval.Day, -7, CDate(Format(Now, "yyyy/MM/dd"))), ">=", "2", Nothing, Nothing)
                Else
                    MsgBox("刪除失敗,請檢查原因!")
                    Exit Sub
                End If
            End If
        Else
            If pfi(0).FP_Type <> "發料" Then
                MsgBox("您隻能對'發料'性質的記錄進行修改刪除操作！")
                Exit Sub
            End If

            If MsgBox("你確定刪除物料收發單號為  '" & GridView1.GetFocusedRowCellValue("FP_NO").ToString & "'  的記錄嗎?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If pfc.ProductionField_Delete(GridView1.GetFocusedRowCellValue("FP_NO").ToString, Nothing) = True Then
                    MsgBox("刪除成功!")
                    '@ 2012/2/21 修改 只顯示當前7天內的記錄
                    Grid.DataSource = pfc.ProductionField_GetList(Nothing, Nothing, "發料", Nothing, pfi(0).FP_OutDep, Nothing, False, False, DateAdd(DateInterval.Day, -7, CDate(Format(Now, "yyyy/MM/dd"))), ">=", "2", Nothing, Nothing)
                Else
                    MsgBox("刪除失敗,請檢查原因!")
                    Exit Sub
                End If
            End If
        End If

        '---------------------------------------------------------------------
        Dim pmi As List(Of LFERP.Library.ProductionMerge.ProductionMergeInfo)
        Dim pmc As New LFERP.Library.ProductionMerge.ProductionMergeControl

        pmi = pmc.ProductionMerge_GetList(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, GridView1.GetFocusedRowCellValue("FP_NO").ToString)
        If pmi.Count > 0 Then
            pmc.ProductionMerge_Delete(Nothing, GridView1.GetFocusedRowCellValue("FP_NO").ToString)  '刪除物料收發中--組合記錄
        End If

        '---------------------------------------------------------------------
    End Sub

    Private Sub MenuCodePreView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCodePreView.Click
        On Error Resume Next

        If GridView1.RowCount = 0 Then Exit Sub
        Dim pfi As List(Of ProductionFieldInfo)
        pfi = pfc.ProductionField_GetList(GridView1.GetFocusedRowCellValue("FP_NO").ToString, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, "1", Nothing, Nothing)

        If pfi(0).FP_Detail = "PT03" Or pfi(0).FP_Detail = "PT04" Then

            Dim fr As frmProductionFieldCodeIn
            For Each fr In MDIMain.MdiChildren
                If TypeOf fr Is frmProductionFieldCodeIn Then
                    fr.Activate()
                    Exit Sub
                End If
            Next
            fr = New frmProductionFieldCodeIn
            tempValue = "PreView"
            tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.Show()
        ElseIf pfi(0).FP_Detail = "PT01" Or pfi(0).FP_Detail = "PT02" Or pfi(0).FP_Detail = "PT12" Or pfi(0).FP_Detail = "PT13" Or pfi(0).FP_Detail = "PT15" Or pfi(0).FP_Detail = "PT16" Or pfi(0).FP_Detail = "PT14" Then
            Dim fr As frmProductionFieldCode
            For Each fr In MDIMain.MdiChildren
                If TypeOf fr Is frmProductionFieldCode Then
                    fr.Activate()
                    Exit Sub
                End If
            Next
            fr = New frmProductionFieldCode
            tempValue = "PreView"
            tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
            tempValue6 = twWare.SelectedNode.Parent.Text  '傳入當前選擇類型（收料/發料）
            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.Show()
        ElseIf pfi(0).FP_Detail = "PT17" And GridView1.GetFocusedRowCellValue("FP_Type") = "收料" Then   '只針對組合工序后收料情況
            Dim fr As frmProductionFieldCodeIn
            For Each fr In MDIMain.MdiChildren
                If TypeOf fr Is frmProductionFieldCodeIn Then
                    fr.Activate()
                    Exit Sub
                End If
            Next
            fr = New frmProductionFieldCodeIn
            tempValue = "PreView"
            tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.Show()
        ElseIf pfi(0).FP_Detail = "PT18" Or pfi(0).FP_Detail = "PT19" Or pfi(0).FP_Detail = "PT20" Then
            Dim fr As frmProductionFieldWare
            For Each fr In Me.MdiChildren
                If TypeOf fr Is frmProductionFieldWare Then
                    fr.Activate()
                    Exit Sub
                End If
            Next
            fr = New frmProductionFieldWare
            tempValue = "PreView"
            tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
            tempValue6 = twWare.SelectedNode.Parent.Text  '傳入當前選擇類型（收料/發料）
            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.Show()
        Else

            Dim fr As frmProductionFieldCodeOut
            For Each fr In MDIMain.MdiChildren
                If TypeOf fr Is frmProductionFieldCodeOut Then
                    fr.Activate()
                    Exit Sub
                End If
            Next
            fr = New frmProductionFieldCodeOut
            tempValue = "PreView"
            tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.Show()
        End If


    End Sub

    '查詢操作.當前已工藝類型,產品資料,類型,日期範圍查詢(默認查詢本部門操作)

    Private Sub MenuCodeQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCodeQuery.Click
        ' ''Dim frm As New frmProductionFieldSelect
        ' ''frm.ShowDialog()
        ' ''If tempValue2 <> "" Or tempValue3 <> "" Or tempValue4 <> "" Or tempValue5 <> "" Or tempValue6 <> "" Or tempValue7 <> "" Or tempValue8 <> "" Then
        ' ''    Grid.DataSource = pfc.ProductionField_GetList1(Nothing, tempValue2, tempValue3, tempValue4, Nothing, tempValue7, Nothing, strDPT, Nothing, Nothing, tempValue8, tempValue5, tempValue6)
        ' ''End If
        ' ''tempValue2 = Nothing
        ' ''tempValue3 = Nothing
        ' ''tempValue4 = Nothing
        ' ''tempValue5 = Nothing
        ' ''tempValue6 = Nothing
        ' ''tempValue7 = Nothing
        ' ''tempValue8 = Nothing


        ''mao2012/3/6 加在查詢收發物料時必須要選擇[收入項目]與[發出項目],在查詢完畢時若選擇的是[收入項目]，則列表中收料工序在前，反之在后
        tempValue9 = ""

        On Error GoTo err1

        If twWare.SelectedNode.Text <> "" Then

            Dim frm As New frmProductionFieldSelect

            If InStr(twWare.SelectedNode.Text, "未審核", CompareMethod.Text) > 0 Then
                If twWare.SelectedNode.Parent.Text = "收入項目" Then
                    tempValue9 = "收料"
                Else
                    tempValue9 = "發料"
                End If
            ElseIf InStr(twWare.SelectedNode.Text, "已審核", CompareMethod.Text) > 0 Then
                If twWare.SelectedNode.Parent.Text = "收入項目" Then
                    tempValue9 = "收料"
                Else
                    tempValue9 = "發料"
                End If
            ElseIf twWare.SelectedNode.Text = "收入項目" Then
                tempValue9 = "收料"
            ElseIf twWare.SelectedNode.Text = "發出項目" Then
                tempValue9 = "發料"
            End If

            If Me.ComboPro_Type.EditValue = "全部" Then
                tempValue13 = Nothing
            Else
                tempValue13 = Me.ComboPro_Type.EditValue
            End If


            frm.ComboBoxEdit2.Text = tempValue9
            frm.ShowDialog()

            If frm.isClickcmdSave = True Then
                If tempValue9 = "收料" Then
                    Pro_NO.Caption = "收料工序" : Pro_NO1.Caption = "發料工序"
                    Grid.DataSource = pfc.ProductionField_GetList1(tempValue, tempValue2, tempValue3, tempValue4, tempValue12, tempValue7, Nothing, strDPT, Nothing, Nothing, tempValue8, tempValue5, tempValue6, tempValue10, tempValue11)
                Else
                    Pro_NO.Caption = "發料工序" : Pro_NO1.Caption = "收料工序"
                    Grid.DataSource = pfc.ProductionField_GetList1(tempValue, tempValue2, tempValue3, tempValue4, tempValue12, tempValue7, Nothing, strDPT, Nothing, Nothing, tempValue8, tempValue5, tempValue6, tempValue10, tempValue11)
                End If
            End If

            tempValue = Nothing
            tempValue2 = Nothing
            tempValue3 = Nothing
            tempValue4 = Nothing
            tempValue5 = Nothing
            tempValue6 = Nothing
            tempValue7 = Nothing
            tempValue8 = Nothing
            tempValue9 = Nothing
            tempValue10 = Nothing
            tempValue11 = Nothing
            tempValue12 = Nothing
            tempValue13 = Nothing
        End If

        Exit Sub
err1:
        MsgBox("請選擇 [收入項目]或[發出項目]...", MsgBoxStyle.Information, "提示")
    End Sub






    '根據部門和審核狀態刷新記錄
    '@2012/1/5改進刷新，調用 ShowData() 過程
    Private Sub MenuCodeRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCodeRef.Click
        If twWare.SelectedNode.Level = 1 Then
            ShowData(Mid(twWare.SelectedNode.Text, 1, 3), Nothing)
        Else
            MsgBox("請選擇審核狀態!", 64, "提示")
            twWare.Select()
        End If
        'Grid.DataSource = pfc.ProductionField_GetList(Nothing, Nothing, "發料", Nothing, strDPT, Nothing, False, False, Nothing, Nothing, "2")
    End Sub

    Private Sub MenuCodeInCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCodeInCheck.Click
        On Error Resume Next
        If GridView1.RowCount = 0 Then Exit Sub

        Dim pfi As List(Of ProductionFieldInfo)

        Dim pfi1 As List(Of ProductionFieldInfo)

        pfi = pfc.ProductionField_GetList(GridView1.GetFocusedRowCellValue("FP_NO").ToString, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, "1", Nothing, Nothing)
        If pfi.Count = 0 Then Exit Sub

        If pfi(0).FP_Check = True Then
            MsgBox("此單號已被審核,不允許進行確認操作!")
            Exit Sub
        End If

        If pfi(0).FP_OutOK = False Then
            MsgBox("此單號發出未確認，不允許進行收料確認操作!")
            Exit Sub
        End If

        If pfi(0).FP_Detail = "PT15" Then
            MsgBox("調賬記錄，不允許再次確認！")
            Exit Sub
        End If
        If pfi(0).FP_Detail = "PT03" Or pfi(0).FP_Detail = "PT04" Then

            Dim fr As frmProductionFieldCodeIn
            For Each fr In MDIMain.MdiChildren
                If TypeOf fr Is frmProductionFieldCodeIn Then
                    fr.Activate()
                    Exit Sub
                End If
            Next
            fr = New frmProductionFieldCodeIn
            tempValue = "InCheck"
            tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.txtQty.Enabled = False
            fr.gluDetail.Enabled = False
            'fr.M_Code.Enabled = False
            fr.Show()

        ElseIf pfi(0).FP_Detail = "PT01" Or pfi(0).FP_Detail = "PT02" Or pfi(0).FP_Detail = "PT12" Or pfi(0).FP_Detail = "PT13" Or pfi(0).FP_Detail = "PT14" Or pfi(0).FP_Detail = "PT15" Or pfi(0).FP_Detail = "PT16" Then
            If GridView1.GetFocusedRowCellValue("FP_Type").ToString <> "收料" Then
                MsgBox("您隻能對'收料'性質的記錄進行確認操作！")
                Exit Sub
            End If


            Dim fr As frmProductionFieldCode
            For Each fr In MDIMain.MdiChildren
                If TypeOf fr Is frmProductionFieldCode Then
                    fr.Activate()
                    Exit Sub
                End If
            Next
            fr = New frmProductionFieldCode
            tempValue = "InCheck"
            tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
            tempValue6 = twWare.SelectedNode.Parent.Text  '傳入當前選擇類型（收料/發料）

            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.txtQty.Enabled = False
            fr.GluDetail.Enabled = False
            fr.ComboBoxEdit1.Enabled = False
            fr.GluEdit1.Enabled = False
            fr.GluEdit2.Enabled = False
            fr.Show()
        ElseIf pfi(0).FP_Detail = "PT18" Or pfi(0).FP_Detail = "PT19" Or pfi(0).FP_Detail = "PT20" Then '2013-8-13


            If GridView1.GetFocusedRowCellValue("FP_Type").ToString <> "收料" Then
                MsgBox("您隻能對'收料'性質的記錄進行確認操作！")
                Exit Sub
            End If


            Dim fr As frmProductionFieldWare
            'For Each fr In Me.MdiChildren
            '    If TypeOf fr Is frmProductionFieldWare Then
            '        fr.Activate()
            '        Exit Sub
            '    End If
            'Next
            fr = New frmProductionFieldWare
            tempValue = "InCheck"
            tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
            tempValue6 = twWare.SelectedNode.Parent.Text  '傳入當前選擇類型（收料/發料）
            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.Show()

        Else


            Dim fr As frmProductionFieldCodeOut
            For Each fr In MDIMain.MdiChildren
                If TypeOf fr Is frmProductionFieldCodeOut Then
                    fr.Activate()
                    Exit Sub
                End If
            Next
            fr = New frmProductionFieldCodeOut
            tempValue = "InCheck"
            tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.txtQty.Enabled = False
            fr.gluDetail.Enabled = False
            'fr.M_Code.Enabled = False
            fr.Show()
        End If



    End Sub

    '不需審核完成物料轉移
    Private Sub MenuCodeCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCodeCheck.Click
        'On Error Resume Next
        'If GridView1.RowCount = 0 Then Exit Sub

        'Dim pfi As List(Of ProductionFieldInfo)
        'pfi = pfc.ProductionField_GetList(GridView1.GetFocusedRowCellValue("FP_NO").ToString, Nothing, Nothing, Nothing, Nothing, Nothing, True, Nothing, "1")

        'If pfi(0).FP_InCheck = False Then
        '    MsgBox("此操作還未被確認,不允許審核!")
        '    Exit Sub
        'End If
        'If GridView1.GetFocusedRowCellValue("FP_Type").ToString <> "收料" Then
        '    MsgBox("您隻能對'收料'性質的記錄進行審核操作！")
        '    Exit Sub
        'End If


        'Dim fr As frmProductionFieldCode
        'For Each fr In MDIMain.MdiChildren
        '    If TypeOf fr Is frmProductionFieldCode Then
        '        fr.Activate()
        '        Exit Sub
        '    End If
        'Next
        'fr = New frmProductionFieldCode
        'tempValue = "CodeCheck"
        'tempValue4 = GridView1.GetFocusedRowCellValue("FP_NO").ToString
        'fr.MdiParent = MDIMain
        'fr.WindowState = FormWindowState.Maximized
        'fr.Show()

    End Sub

    '開料
    Private Sub smKaiLiao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smKaiLiao.Click
        tempValue5 = strDPT
        Dim fr As New frmLoadKaiLiao
        fr.Left = MDIMain.Width / 2 - 150
        fr.Top = Me.Top + 200
        fr.ShowDialog()
    End Sub
    '加存
    Private Sub smJiaCun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smJiaCun.Click
        On Error Resume Next
        Edit = False
        Dim fr As frmProductionFieldCodeIn
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionFieldCodeIn Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionFieldCodeIn
        tempValue = "CodeIn"
        tempValue2 = "PT04"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()

    End Sub
    '大貨
    Private Sub smDaHuo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smDaHuo.Click
        'On Error Resume Next

        Edit = False

        Dim fr As frmProductionFieldCode
        'For Each fr In MDIMain.MdiChildren
        '    If TypeOf fr Is frmProductionFieldCode Then
        '        fr.Activate()
        '        Exit Sub
        '    End If
        'Next
        fr = New frmProductionFieldCode
        tempValue = "CodeOut"
        tempValue2 = "PT01"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub
    '返修
    Private Sub smFanXiu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smFanXiu.Click
        On Error Resume Next

        Edit = False

        Dim fr As frmProductionFieldCode
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionFieldCode Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionFieldCode
        tempValue = "CodeOut"
        tempValue2 = "PT02"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub
    '損壞
    Private Sub smSunHuai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smSunHuai.Click
        On Error Resume Next

        Edit = False

        Dim fr As frmProductionFieldCodeOut
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionFieldCodeOut Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionFieldCodeOut
        tempValue = "CodeHouse"
        tempValue2 = "PT07"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub
    '丟失
    Private Sub smDiuShi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smDiuShi.Click
        On Error Resume Next

        Edit = False

        Dim fr As frmProductionFieldCodeOut
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionFieldCodeOut Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionFieldCodeOut
        tempValue = "CodeHouse"
        tempValue2 = "PT08"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub
    '不良
    Private Sub smBuLiang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smBuLiang.Click
        On Error Resume Next

        Edit = False

        Dim fr As frmProductionFieldCodeOut
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionFieldCodeOut Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionFieldCodeOut
        tempValue = "CodeHouse"
        tempValue2 = "PT10"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub
    '留辦
    Private Sub smLiuBan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smLiuBan.Click
        On Error Resume Next

        Edit = False

        Dim fr As frmProductionFieldCodeOut
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionFieldCodeOut Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionFieldCodeOut
        tempValue = "CodeHouse"
        tempValue2 = "PT06"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub
    '存貨
    Private Sub smCunHuo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smCunHuo.Click
        On Error Resume Next

        Edit = False

        Dim fr As frmProductionFieldCodeOut
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionFieldCodeOut Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionFieldCodeOut
        tempValue = "CodeHouse"
        tempValue2 = "PT09"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub
    '存倉
    Private Sub smCunCang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smCunCang.Click
        On Error Resume Next

        Edit = False

        Dim fr As frmProductionFieldCode
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionFieldCode Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionFieldCode
        tempValue = "CodeOut"
        tempValue2 = "PT12"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub
    '完工
    Private Sub smChuHuo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smChuHuo.Click
        On Error Resume Next

        If MsgBox("你確定此工序要進行完工處理嗎?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            'MsgBox("請將收料部門選擇為當前部門所對應的生產部倉庫！")

            Edit = False
            Dim fr As frmProductionFieldCode
            For Each fr In MDIMain.MdiChildren
                If TypeOf fr Is frmProductionFieldCode Then
                    fr.Activate()
                    Exit Sub
                End If
            Next
            fr = New frmProductionFieldCode
            tempValue = "CodeOut"
            tempValue2 = "PT13"
            tempValue5 = strDPT
            fr.MdiParent = MDIMain
            fr.WindowState = FormWindowState.Maximized
            fr.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub smWaiFa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smWaiFa.Click
        On Error Resume Next

        Edit = False

        Dim fr As frmProductionFieldCode
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionFieldCode Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionFieldCode
        tempValue = "CodeOut"
        tempValue2 = "PT14"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()

    End Sub

    '先查詢后進行收發導出功能
    Private Sub MenuCodeExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCodeExport.Click
        On Error Resume Next

        If GridView1.RowCount = 0 Then Exit Sub

        Dim strType As String

        strType = GridView1.GetFocusedRowCellValue("FP_Type").ToString

        If MsgBox("你確定要當前所有的資料嗎?", MsgBoxStyle.YesNo, "提示") = MsgBoxResult.No Then Exit Sub

        Dim exapp As New Excel.Application
        Dim exbook As Excel.Workbook
        Dim exsheet As Excel.Worksheet

        Dim i As Integer = 0, ii As Integer = 0

        exapp = CreateObject("Excel.Application")
        exbook = exapp.Workbooks.Add
        exsheet = exapp.Worksheets(1)


        exsheet.Cells(1, 1) = "收發單號"
        exsheet.Cells(1, 2) = "工藝類型"
        exsheet.Cells(1, 3) = "產品編號"
        exsheet.Cells(1, 4) = "類型"

        If strType = "發料" Then
            exsheet.Cells(1, 5) = "發料工序"
            exsheet.Cells(1, 6) = "收料工序"
        Else
            exsheet.Cells(1, 5) = "收料工序"
            exsheet.Cells(1, 6) = "發料工序"
        End If

        exsheet.Cells(1, 7) = "部門"
        exsheet.Cells(1, 8) = "變更部門"
        exsheet.Cells(1, 9) = "數量"
        exsheet.Cells(1, 10) = "收發類型"
        exsheet.Cells(1, 11) = "屬性"
        exsheet.Cells(1, 12) = "操作員"
        exsheet.Cells(1, 13) = "確認員"
        exsheet.Cells(1, 14) = "備註"
        exsheet.Cells(1, 15) = "操作時間"

        For i = 0 To GridView1.RowCount - 1
            ii = i + 2

            exsheet.Cells(ii, 1) = GridView1.GetRowCellValue(i, "FP_NO")
            exsheet.Cells(ii, 2) = GridView1.GetRowCellValue(i, "Pro_Type")
            exsheet.Cells(ii, 3) = GridView1.GetRowCellValue(i, "PM_M_Code")
            exsheet.Cells(ii, 4) = GridView1.GetRowCellValue(i, "PM_Type")
            exsheet.Cells(ii, 5) = GridView1.GetRowCellValue(i, "PS_Name")
            exsheet.Cells(ii, 6) = GridView1.GetRowCellValue(i, "PS_Name1")
            exsheet.Cells(ii, 7) = GridView1.GetRowCellValue(i, "DepOutName")
            exsheet.Cells(ii, 8) = GridView1.GetRowCellValue(i, "DepInName")
            exsheet.Cells(ii, 9) = GridView1.GetRowCellValue(i, "FP_Qty")
            exsheet.Cells(ii, 10) = GridView1.GetRowCellValue(i, "FP_Type")
            exsheet.Cells(ii, 11) = GridView1.GetRowCellValue(i, "PT_Type")
            exsheet.Cells(ii, 12) = GridView1.GetRowCellValue(i, "FP_OutActionName")
            exsheet.Cells(ii, 13) = GridView1.GetRowCellValue(i, "FP_InActionName")
            exsheet.Cells(ii, 14) = GridView1.GetRowCellValue(i, "FP_Remark")
            exsheet.Cells(ii, 15) = GridView1.GetRowCellValue(i, "FP_Date")
        Next
        exapp.Visible = True
    End Sub

    '@ 2012/8/21 添加 按回車鍵調用鼠標彈起過程,加載數據
    Private Sub GridControl2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl2.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridControl2_MouseUp(Nothing, Nothing)
        End If
    End Sub

    '指定當前部門物料收發信息記錄
    Private Sub GridControl2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridControl2.MouseUp
        If GridView2.RowCount = 0 Then Exit Sub

        strDPT = GridView2.GetFocusedRowCellValue("ControlDep").ToString

        If strDPT = "F101" Then
            'FP_OutType.Visible = True
            'chkOutProcess.Visible = True
            'chkBlocProcess.Visible = True
            If InUserID = "第一生產倉" Or InUserID = "第二生產倉" Or InUserID = "第三生產倉" Then
                MenuCodeInAdd.Visible = False

                smDaHuo.Visible = True
                smChuHuo.Visible = False
                smZuhe.Visible = False
                smChaiFen.Visible = False
                smFanXiu.Visible = False
                smRePairOut.Visible = False
                smWaiFa.Visible = False
                smSunHuai.Visible = False
                smDiuShi.Visible = False
                smBuLiang.Visible = False
                smLiuBan.Visible = False
                smCunHuo.Visible = False
                smCunCang.Visible = False
                'smChengPin.Visible = False   '送成品倉
            Else
                MenuCodeInAdd.Visible = False

                smDaHuo.Visible = False
                smChuHuo.Visible = False
                smZuhe.Visible = False
                smChaiFen.Visible = False
                smFanXiu.Visible = True
                smRePairOut.Visible = False
                smWaiFa.Visible = True
                smSunHuai.Visible = False
                smDiuShi.Visible = False
                smBuLiang.Visible = False
                smLiuBan.Visible = False
                smCunHuo.Visible = False
                smCunCang.Visible = False
                'smChengPin.Visible = False   '送成品倉

                smFanXiu.Visible = True '2013-3-22
            End If

            smChengPin.Visible = True   '送成品倉
        Else
            'FP_OutType.Visible = False
            'chkOutProcess.Visible = False
            'chkBlocProcess.Visible = False

            MenuCodeInAdd.Visible = True

            ' smJiaCun.Visible = False
            smJiaCun.Visible = True

            smDaHuo.Visible = True
            smChuHuo.Visible = True
            smZuhe.Visible = True
            smChaiFen.Visible = True
            smFanXiu.Visible = True
            smRePairOut.Visible = True
            smWaiFa.Visible = True
            smSunHuai.Visible = True
            smDiuShi.Visible = True
            smBuLiang.Visible = True
            smLiuBan.Visible = True
            smCunHuo.Visible = True
            smCunCang.Visible = True

            'If InUserID = "第一裝配" Or InUserID = "第二裝配" Or InUserID = "第三裝配" Then
            '    smChengPin.Visible = True   '送成品倉
            'Else
            '    smChengPin.Visible = False   '送成品倉
            'End If

            If CInt(InStr(GridView2.GetFocusedRowCellValue("DepName").ToString, "裝配")) >= 1 Then
                smChengPin.Visible = True   '送成品倉
            Else
                smChengPin.Visible = False   '送成品倉
            End If

            ' If CInt(InStr(GridView2.GetFocusedRowCellValue("DepName").ToString, "燒焊")) >= 1 Or CInt(InStr(GridView2.GetFocusedRowCellValue("DepName").ToString, "組裝")) >= 1 Then '2012-6-2
            If smChaiFenZuhe = True Then
                smChaiFen.Visible = True
                smZuhe.Visible = True
            Else
                smChaiFen.Visible = False
                smZuhe.Visible = False
            End If

        End If

        twWare.ExpandAll()
        Try
            Dim a As New Library.ProductionField.ProductionFieldControl

            Dim b As New List(Of ProductionFieldInfo)
            Dim c As New List(Of ProductionFieldInfo)

            ' b = a.ProductionField_GetList(Nothing, Nothing, "發料", Nothing, strDPT, Nothing, Nothing, False, Nothing, Nothing, "2", Nothing, Nothing)
            ' c = a.ProductionField_GetList(Nothing, Nothing, "收料", Nothing, strDPT, Nothing, Nothing, False, Nothing, Nothing, "2", Nothing, Nothing)

            Dim strComboPro_Type As String = Nothing

            If ComboPro_Type.EditValue = "全部" Then
                strComboPro_Type = Nothing
            Else
                strComboPro_Type = ComboPro_Type.EditValue
            End If


            b = a.ProductionField_GetList3(Nothing, Nothing, "發料", Nothing, strDPT, Nothing, Nothing, False, Nothing, Nothing, "2", Nothing, Nothing, strComboPro_Type, Nothing)
            c = a.ProductionField_GetList3(Nothing, Nothing, "收料", Nothing, strDPT, Nothing, Nothing, False, Nothing, Nothing, "2", Nothing, Nothing, strComboPro_Type, Nothing)


            If b.Count > 0 Then

                twWare.Nodes.Item(1).Nodes.Item(0).Text = "未審核 (" & b.Count & ")"
            Else
                twWare.Nodes.Item(1).Nodes.Item(0).Text = "未審核"
            End If

            If c.Count > 0 Then
                twWare.Nodes.Item(0).Nodes.Item(0).Text = "未審核 (" & c.Count & ")"
            Else
                twWare.Nodes.Item(0).Nodes.Item(0).Text = "未審核"
            End If

        Catch ex As Exception

        End Try

    End Sub
    '補返修發出－－（收料確認時變更大貨數量）
    Private Sub smRePairOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smRePairOut.Click
        On Error Resume Next

        Edit = False

        Dim fr As frmProductionFieldCode
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionFieldCode Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionFieldCode
        tempValue = "CodeOut"
        tempValue2 = "PT16"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()

    End Sub

    Private Sub smZuhe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smZuhe.Click
        On Error Resume Next

        Dim fr As frmProductionCombination
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is frmProductionCombination Then
                fr.Activate()
                Exit Sub
            End If
        Next
        fr = New frmProductionCombination
        tempValue2 = "組合"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()

    End Sub

    Private Sub smChaiFen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smChaiFen.Click
        Dim fr As New frmProductionCombination

        tempValue2 = "拆分"
        tempValue5 = strDPT
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub

    Private Sub smChengPin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smChengPin.Click


        ' ''On Error Resume Next

        ''If MsgBox("你確定要將產品送至成品倉嗎?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        ''    'Edit = False
        ''    Dim fr As frmProductionFieldCode1
        ''    'For Each fr In MDIMain.MdiChildren
        ''    '    If TypeOf fr Is frmProductionFieldCode1 Then
        ''    '        fr.Activate()
        ''    '        Exit Sub
        ''    '    End If
        ''    'Next
        ''    fr = New frmProductionFieldCode1
        ''    'tempValue = "CodeOut"
        ''    'tempValue2 = "PT13"  '完工
        ''    'tempValue5 = strDPT
        ''    'tempValue10 = "成品倉"
        ''    fr.txtDepID_Out.Tag = strDPT
        ''    fr.txtDepID_Out.Text = GridView2.GetFocusedRowCellValue("DepName").ToString
        ''    fr.MdiParent = MDIMain
        ''    fr.WindowState = FormWindowState.Maximized
        ''    fr.Show()
        ''End If

    End Sub

    Private Sub chkOutProcess_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOutProcess.CheckedChanged
        If chkOutProcess.Checked = True Then
            chkBlocProcess.Checked = False
            ShowData(Mid(twWare.SelectedNode.Text, 1, 3), "外發加工")
        Else
            ShowData(Mid(twWare.SelectedNode.Text, 1, 3), Nothing)
        End If
    End Sub

    Private Sub chkBlocProcess_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBlocProcess.CheckedChanged
        If chkBlocProcess.Checked = True Then
            chkOutProcess.Checked = False
            ShowData(Mid(twWare.SelectedNode.Text, 1, 3), "集團內部加工")
        Else
            ShowData(Mid(twWare.SelectedNode.Text, 1, 3), Nothing)
        End If
    End Sub

    Private Sub DeltialMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeltialMenuItem.Click

        Dim fr As New frmProductionFieldCollect
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()

    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If twWare.SelectedNode.Level = 0 Then
            If twWare.SelectedNode.Text = "收入項目" Then
                tempValue11 = "收料"
            Else
                tempValue11 = "發料"
            End If
        Else
            If twWare.SelectedNode.Parent.Text = "收入項目" Then
                tempValue11 = "收料"
            Else
                tempValue11 = "發料"
            End If
        End If

        Dim fr As New frmProductionFind
        fr.ShowDialog()
        If fr.isClickbtnFind = True Then
            Grid.DataSource = pfc.ProductionField_GetList1(Nothing, tempValue, tempValue2, tempValue3, tempValue4, tempValue5, Nothing, strDPT, Nothing, Nothing, tempValue8, tempValue6, tempValue7, tempValue9, tempValue10)
        End If

        tempValue = Nothing
        tempValue2 = Nothing
        tempValue3 = Nothing
        tempValue4 = Nothing
        tempValue5 = Nothing
        tempValue6 = Nothing
        tempValue7 = Nothing
        tempValue8 = Nothing
        tempValue9 = Nothing
        tempValue10 = Nothing
    End Sub

    Private Sub MenuCodeRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCodeRecord.Click
        Dim fr As New frmProductionFieldCollect
        fr.Label1.Text = "部門物料收發記錄"
        fr.Label1.Tag = "SFJL"
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub

    Private Sub GridControl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl2.Click
    End Sub

    '2013-8-20 加
    Private Sub ToolWareFaLiao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolWareFaLiao.Click

        If GridView2.RowCount <= 0 Then Exit Sub
        Dim StrDepA As String = GridView2.GetFocusedRowCellValue("ControlDep").ToString

        If StrDepA = "" Then
            MsgBox("請選擇部門!")
        End If

        Edit = False

        Dim fr As frmProductionFieldWare
        'For Each fr In Me.MdiChildren
        '    If TypeOf fr Is frmProductionFieldWare Then
        '        fr.Activate()
        '        Exit Sub
        '    End If
        'Next
        fr = New frmProductionFieldWare
        tempValue = "CodeOut"
        tempValue2 = "PT18"
        tempValue3 = StrDepA

        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub

    Private Sub ToolWaiFaASS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolWaiFaASS.Click
        If GridView2.RowCount <= 0 Then Exit Sub
        Dim StrDepA As String = GridView2.GetFocusedRowCellValue("ControlDep").ToString

        If StrDepA = "" Then
            MsgBox("請選擇部門!")
        End If

        Edit = False

        Dim fr As frmProductionFieldWare
        'For Each fr In Me.MdiChildren
        '    If TypeOf fr Is frmProductionFieldWare Then
        '        fr.Activate()
        '        Exit Sub
        '    End If
        'Next
        fr = New frmProductionFieldWare
        tempValue = "CodeOut"
        tempValue2 = "PT19"
        tempValue3 = StrDepA

        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub

    Private Sub ToolASSBuNiang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolASSBuNiang.Click
        If GridView2.RowCount <= 0 Then Exit Sub
        Dim StrDepA As String = GridView2.GetFocusedRowCellValue("ControlDep").ToString

        If StrDepA = "" Then
            MsgBox("請選擇部門!")
        End If

        Edit = False

        Dim fr As frmProductionFieldWare
        'For Each fr In Me.MdiChildren
        '    If TypeOf fr Is frmProductionFieldWare Then
        '        fr.Activate()
        '        Exit Sub
        '    End If
        'Next
        fr = New frmProductionFieldWare
        tempValue = "CodeOut"
        tempValue2 = "PT20"
        tempValue3 = StrDepA

        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub

    Private Sub ToolStripLiuBan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLiuBan.Click
        ''留辦-加存報表
        Dim fr As New frmProductionFieldCollect
        fr.Label1.Tag = "LBJC"
        fr.Label1.Text = "留辦加存記錄"
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()

    End Sub
End Class