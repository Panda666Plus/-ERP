Imports LFERP.Library.Outward.OutwardAcceptance
Imports LFERP.SystemManager
Imports LFERP.DataSetting

Public Class FormAcceptanceMain

    Private Sub FormAcceptanceMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oc As New OutwardAcceptanceControl

        Grid1.DataSource = oc.OutwardAcceptance_GetList(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        LoadUserPower()
    End Sub
    Sub LoadUserPower()
        Dim pmws As New PermissionModuleWarrantSubController
        Dim pmwiL As List(Of PermissionModuleWarrantSubInfo)

        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "700201")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then popAcceptanceAdd.Enabled = True
        End If

        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "700202")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then popAcceptanceEdit.Enabled = True
        End If


        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "700203")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then popAcceptanceDel.Enabled = True
        End If


        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "700204")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then popAcceptanceCheck.Enabled = True
        End If


        pmwiL = pmws.PermissionModuleWarrantSub_GetList(InUserID, "700205")
        If pmwiL.Count > 0 Then
            If pmwiL.Item(0).PMWS_Value = "是" Then popAcceptanceAccCheck.Enabled = True
        End If


    End Sub

    Private Sub popAcceptanceRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popAcceptanceRef.Click
        Dim oc As New OutwardAcceptanceControl

        Grid1.DataSource = oc.OutwardAcceptance_GetList(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
    End Sub

    Private Sub popAcceptanceAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popAcceptanceAdd.Click
        On Error Resume Next
        Edit = False
        Dim fr As FormAcceptance
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is FormAcceptance Then
                fr.Activate()
                Exit Sub
            End If
        Next
        MTypeName = "OutwardAcceptanceAddEdit"
        fr = New FormAcceptance
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub

  
    Private Sub popAcceptanceEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popAcceptanceEdit.Click
        On Error Resume Next
        Dim osc As New OutwardAcceptanceControl
        Dim osilist As List(Of OutwardAcceptanceInfo)
        osilist = osc.OutwardAcceptance_GetList(GridView1.GetFocusedRowCellValue("A_AcceptanceNO").ToString, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        If osilist(0).A_Check = True Or osilist(0).A_AccCheck = True Then
            MsgBox("此验收單已審核或復核，不允許修改！")
            Exit Sub
        End If
     
        Edit = True

        Dim fr As FormAcceptance
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is FormAcceptance Then
                fr.Activate()
                Exit Sub
            End If
        Next

        MTypeName = "OutwardAcceptanceAddEdit"
        fr = New FormAcceptance
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        tempValue2 = GridView1.GetFocusedRowCellValue("A_AcceptanceNO").ToString
        fr.Show()
    End Sub

    Private Sub popAcceptanceDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popAcceptanceDel.Click
        Dim StrA As String
        StrA = GridView1.GetFocusedRowCellValue("A_AcceptanceNO").ToString
        If MsgBox("你確定刪除驗收單號為  '" & StrA & "'  的記錄嗎?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim mc As New OutwardAcceptanceInfo
            Dim mt As New OutwardAcceptanceControl
            mc.A_AcceptanceNO = StrA
            If mt.OutwardAcceptance_Delete(mc.A_AcceptanceNO, Nothing) = True Then

                Grid1.DataSource = mt.OutwardAcceptance_GetList(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            Else
                MsgBox("刪除失敗")
            End If

        End If
    End Sub

    Private Sub popAcceptanceView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popAcceptanceView.Click
        On Error Resume Next

        If GridView1.RowCount = 0 Then Exit Sub
        Dim fr As FormAcceptance
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is FormAcceptance Then
                fr.Activate()
                Exit Sub
            End If
        Next

        MTypeName = "OutwardAcceptanceView"
        fr = New FormAcceptance
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        tempValue2 = GridView1.GetFocusedRowCellValue("A_AcceptanceNO").ToString
        fr.Show()
    End Sub

    Private Sub popAcceptanceCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popAcceptanceCheck.Click
        On Error Resume Next
        Dim osc As New OutwardAcceptanceControl
        Dim osilist As List(Of OutwardAcceptanceInfo)
        osilist = osc.OutwardAcceptance_GetList(GridView1.GetFocusedRowCellValue("A_AcceptanceNO").ToString, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        If osilist(0).A_AccCheck = True Then
            MsgBox("此验收單已審核，不允許修改！")
            Exit Sub
        End If

        'Dim fr As FormAcceptance
        'For Each fr In MDIMain.MdiChildren
        '    If TypeOf fr Is FormAcceptance Then
        '        fr.Activate()
        '        Exit Sub
        '    End If
        'Next

        MTypeName = "OutwardAcceptanceCheck"
        Dim fr As New FormAcceptance
        'fr.MdiParent = MDIMain
        'fr.WindowState = FormWindowState.Maximized
        tempValue2 = GridView1.GetFocusedRowCellValue("A_AcceptanceNO").ToString
        fr.ShowDialog()
    End Sub

    Private Sub popAcceptanceAccCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popAcceptanceAccCheck.Click
        On Error Resume Next
        Dim osc As New OutwardAcceptanceControl
        Dim osilist As List(Of OutwardAcceptanceInfo)

        Dim ac As New OutwardAcceptanceControl
        Dim ai As New OutwardAcceptanceInfo

        osilist = osc.OutwardAcceptance_GetList(GridView1.GetFocusedRowCellValue("A_AcceptanceNO").ToString, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        If osilist(0).A_Check = False Then
            MsgBox("必須先驗收,會計部才能審核!")
            Exit Sub
        End If

        Dim fr As FormAcceptance
        For Each fr In MDIMain.MdiChildren
            If TypeOf fr Is FormAcceptance Then
                fr.Activate()
                Exit Sub
            End If
        Next
        tempValue2 = GridView1.GetFocusedRowCellValue("A_AcceptanceNO").ToString
        MTypeName = "OutwardAcceptanceAccCheck"
        fr = New FormAcceptance
        fr.MdiParent = MDIMain
        fr.WindowState = FormWindowState.Maximized
        fr.Show()
    End Sub

    Private Sub popAcceptanceSeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popAcceptanceSeek.Click
        Dim mc As New OutwardAcceptanceControl
        Dim myfrm As New formA_AcceptanceSelect
        myfrm.ShowDialog()
        Select Case tempValue
            Case "1"
                Grid1.DataSource = mc.OutwardAcceptance_GetList(tempValue2, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            Case "2"
                Grid1.DataSource = mc.OutwardAcceptance_GetList(Nothing, Nothing, Nothing, tempValue2, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            Case "3"
                Grid1.DataSource = mc.OutwardAcceptance_GetList(Nothing, Nothing, tempValue2, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            Case "4"
                Grid1.DataSource = mc.OutwardAcceptance_GetList(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, tempValue2, Nothing, Nothing)
            Case "5"
                Grid1.DataSource = mc.OutwardAcceptance_GetList(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, tempValue2)
            Case "6"
                Grid1.DataSource = mc.OutwardAcceptance_GetList(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, tempValue2, Nothing)

        End Select

        tempValue = ""
        tempValue2 = "'"
    End Sub

    '送貨詳細表---當前選定的驗收單明細
    Private Sub popAcceptancePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popAcceptancePrint.Click
        Dim ds As New DataSet

        If GridView1.RowCount = 0 Then Exit Sub

        Dim ltc1 As New CollectionToDataSet
        Dim ltc2 As New CollectionToDataSet

        Dim mcOutwardAcc As New OutwardAcceptanceControl
        Dim mcSupplier As New LFERP.DataSetting.SuppliersControler

        ds.Tables.Clear()

        Dim strA As String

        strA = GridView1.GetFocusedRowCellValue("A_AcceptanceNO").ToString

        ltc1.CollToDataSet(ds, "OutwardAcceptance", mcOutwardAcc.OutwardAcceptance_GetList(strA, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
        ltc2.CollToDataSet(ds, "Suppliers", mcSupplier.GetSuppliersList(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, "True"))

        PreviewRPT(ds, "rptOutwardAcceptanceReturn", "供應商送貨單", True, True)

        ltc1 = Nothing
        ltc2 = Nothing

    End Sub
End Class