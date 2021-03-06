Imports LFERP.Library.Outward.OutwardAcceptance
Imports LFERP.Library.Outward
Imports LFERP.Library.Purchase.SharePurchase

Public Class FormRetrocede
    Dim ds As New DataSet
    Dim OldCheckA As Boolean
    Dim OldCheckB As Boolean
    Private Sub FormRetrocede_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPMID.Text = tempValue2
        Label23.Text = MTypeName
        tempValue2 = ""
        MTypeName = ""
        Dim mtd As New LFERP.DataSetting.SuppliersControler
        gluSupplier.Properties.DisplayMember = "S_SupplierName"
        gluSupplier.Properties.ValueMember = "S_Supplier"
        gluSupplier.Properties.DataSource = mtd.GetSuppliersList(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, "True")
        CreateTable()
      
        Select Case Label23.Text
            Case "RetrocedeAddEdit"
                getenable(True, False, False)
                If Edit = False Then
                    Label3.Text = InUserID
                    Label2.Text = "1"
                    DateEdit1.Text = Format(Now, "yyyy/MM/dd")
                    Me.Text = "外發退貨--新增"
                Else
                    LoadData(txtPMID.Text)
                    Me.Text = "外發退貨--修改" & "[" & txtPMID.Text & "]"
                End If
                XtraTabControl1.SelectedTabPage = XtraTabPage1
            Case "RetrocedeCheck"
                getenable(False, True, False)
                LoadData(txtPMID.Text)
                XtraTabControl1.SelectedTabPage = XtraTabPage2
                DateEdit2.EditValue = Format(Now, "yyyy/MM/dd")
                Me.Text = "外發退貨--審核" & "[" & txtPMID.Text & "]"
            Case "RetrocedeAccountCheck"
                getenable(False, False, True)
                LoadData(txtPMID.Text)
                XtraTabControl1.SelectedTabPage = XtraTabPage3
                DateEdit3.EditValue = Format(Now, "yyyy/MM/dd")
                Me.Text = "外發退貨--復核" & "[" & txtPMID.Text & "]"
            Case "RetrocedeView"
                getenable(False, False, False)
                LoadData(txtPMID.Text)
                XtraTabControl1.SelectedTabPage = XtraTabPage1
                Me.Text = "外發退貨--查看" & "[" & txtPMID.Text & "]"
        End Select
        txtPMID.Enabled = False
        gluSupplier.Enabled = False
        ButtonEdit1.Enabled = False
        ButtonEdit1.EditValue = "W0701"
    End Sub
    Private Function LoadData(ByVal R_RetrocedeNO As String) As Boolean

        LoadData = True
        Dim orc As New OutwardRetrocedeControl
        Dim ori As List(Of OutwardRetrocedeInfo)
        ori = orc.OutwardRetrocede_GetList(R_RetrocedeNO, Nothing, Nothing, Nothing, Nothing, Nothing)
        '''''''''''''''''''''''1''''''''''''''''''
        ButtonEdit1.Text = ori(0).WH_ID
        gluSupplier.EditValue = ori(0).S_Supplier
        DateEdit1.Text = ori(0).R_ReturnDate
        Label2.Text = ori(0).R_Ver
        Label3.Text = ori(0).R_Action
        txtRemark.Text = ori(0).R_RemarkT
        ''''''''''''''''''''''2'''''''''''''''''''

        If ori(0).R_Check = False Then
            CheckEdit1.Checked = False
            OldCheckA = False
        Else
            CheckEdit1.Checked = True
            OldCheckA = True
        End If

        Label5.Text = ori(0).R_CheckAction
        DateEdit2.Text = ori(0).R_CheckDate
        CBA_CheckType.Text = ori(0).R_CheckType
        MemoEdit1.Text = ori(0).R_CheckRemark


        '''''''''''''''''''''''3'''''''''''''''''
        If ori(0).R_AccountCheck = False Then
            CheckEdit2.Checked = False
            OldCheckB = False
        Else
            CheckEdit2.Checked = True
            OldCheckB = True
        End If
        Label17.Text = ori(0).R_AccountAction
        DateEdit3.Text = ori(0).R_AccountCheckDate
        ComboBoxEdit1.Text = ori(0).R_AccountCheckType
        MemoEdit2.Text = ori(0).R_AccountCheckRemark

        Try
            For i As Integer = 0 To ori.Count - 1
                Dim row As DataRow = ds.Tables("OutwardRetrocede").NewRow

                row("R_NO") = ori(i).R_NO
                row("A_AcceptanceNO") = ori(i).A_AcceptanceNO
                row("M_Code") = ori(i).M_Code
                row("M_Unit") = ori(i).M_Unit
                row("M_Name") = ori(i).M_Name
                row("M_Gauge") = ori(i).M_Gauge
                row("OS_BatchID") = ori(i).OS_BatchID
                row("A_SendNO") = ori(i).A_SendNO
                row("R_Qty") = ori(i).R_Qty
                row("R_Reason") = ori(i).R_Reason
                row("R_ReturnType") = ori(i).R_ReturnType
                row("R_Detail") = ori(i).R_Detail
                row("O_NO") = ori(i).O_NO
                row("R_SendDate") = ori(i).R_SendDate
                row("PM_M_Code") = ori(i).PM_M_Code

                ds.Tables("OutwardRetrocede").Rows.Add(row)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            LoadData = False
        End Try
    End Function

    Private Sub getenable(ByVal a As String, ByVal b As String, ByVal c As String)
        '''''''''''''''''''1'''''''''''''''''''''''''
        txtPMID.Enabled = a
        gluSupplier.Enabled = a
        ButtonEdit1.Enabled = a
        DateEdit1.Enabled = a
        txtRemark.Enabled = a
        AdvBandedGridView1.OptionsBehavior.AutoSelectAllInEditor = a
        AdvBandedGridView1.OptionsBehavior.Editable = a
        AdvBandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = a
        ''''''''''''''''''2''''''''''''''''''''
        CheckEdit1.Enabled = b
        CBA_CheckType.Enabled = b
        DateEdit2.Enabled = b
        MemoEdit1.Enabled = b
        ''''''''''''''''''3''''''''''''''''''
        CheckEdit2.Enabled = c
        ComboBoxEdit1.Enabled = c
        DateEdit3.Enabled = c
        MemoEdit2.Enabled = c

    End Sub
    Private Sub CreateTable()

        ds.Tables.Add("OutwardRetrocede")
        With ds.Tables("OutwardRetrocede")
            .Columns.Add("R_NO", GetType(String))
            .Columns.Add("R_RetrocedeNO", GetType(String))
            .Columns.Add("A_AcceptanceNO", GetType(String))
            .Columns.Add("O_NO", GetType(String))
            .Columns.Add("WH_ID", GetType(String))
            .Columns.Add("S_Supplier", GetType(String))
            '.Columns.Add("S_SupplierNO", GetType(String))
            .Columns.Add("A_SendNO", GetType(String))
            .Columns.Add("R_ReturnDate", GetType(Date))
            .Columns.Add("M_Code", GetType(String))
            .Columns.Add("M_Unit", GetType(String))
            .Columns.Add("M_Name", GetType(String))
            .Columns.Add("M_Gauge", GetType(String))
            .Columns.Add("OS_BatchID", GetType(String))
            .Columns.Add("R_Qty", GetType(String))
            .Columns.Add("R_RemarkS", GetType(String))
            .Columns.Add("R_Reason", GetType(String))
            .Columns.Add("R_RemarkT", GetType(String))
            .Columns.Add("R_SendDate", GetType(Date))
            .Columns.Add("R_ReturnType", GetType(String))
            .Columns.Add("R_Check", GetType(Boolean))
            .Columns.Add("R_CheckAction", GetType(String))
            .Columns.Add("R_CheckDate", GetType(Date))
            .Columns.Add("R_CheckType", GetType(String))
            .Columns.Add("R_CheckRemark", GetType(String))
            .Columns.Add("R_AccountCheck", GetType(Boolean))
            .Columns.Add("R_AccountAction", GetType(String))
            .Columns.Add("R_AccountCheckDate", GetType(Date))
            .Columns.Add("R_AccountCheckType", GetType(String))
            .Columns.Add("R_AccountCheckReamrk", GetType(String))
            .Columns.Add("PM_M_Code", GetType(String))
            .Columns.Add("R_Detail", GetType(String))

        End With
        With ds.Tables.Add("DelOutwardRetrocede")
            .Columns.Add("R_NO", GetType(String))
        End With
        Grid.DataSource = ds.Tables("OutwardRetrocede")
    End Sub
    Private Sub popRetrocedeAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popRetrocedeAdd.Click
        Dim fr As New FormRetrocedeSelect
        Dim n As Integer, i As Integer
        Dim oac As New OutwardAcceptanceControl
        Dim oai As New List(Of OutwardAcceptanceInfo)
        fr.ShowDialog()
        If tempValue = "" Then Exit Sub

        Dim arr(n) As String
        arr = Split(tempValue, ",")
        n = Len(Replace(tempValue, ",", "," & "*")) - Len(tempValue)

        For i = 0 To n
            oai = oac.OutwardAcceptance_GetList(Nothing, arr(i), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim row As DataRow = ds.Tables("OutwardRetrocede").NewRow
            row("A_AcceptanceNO") = oai(0).A_AcceptanceNO
            row("A_SendNO") = oai(0).A_SendNO
            row("M_Code") = oai(0).M_Code
            row("M_Unit") = oai(0).M_Unit
            row("M_Name") = oai(0).M_Name
            row("M_Gauge") = oai(0).M_Gauge
            row("OS_BatchID") = oai(0).OS_BatchID
            row("PM_M_Code") = oai(0).PM_M_Code
            row("O_NO") = oai(0).O_NO
            row("R_Qty") = oai(0).A_Qty
            ds.Tables("OutwardRetrocede").Rows.Add(row)
            AdvBandedGridView1.MoveLast()
            gluSupplier.EditValue = oai(0).S_Supplier
        Next
        tempValue = ""
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub popRetrocedeDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popRetrocedeDel.Click
        If AdvBandedGridView1.RowCount = 0 Then Exit Sub
        Dim TempDel As String
        TempDel = AdvBandedGridView1.GetRowCellDisplayText(ArrayToString(AdvBandedGridView1.GetSelectedRows()), "R_NO")
        TempDel = AdvBandedGridView1.GetRowCellDisplayText(AdvBandedGridView1.FocusedRowHandle, "R_NO")
        If TempDel = "R_NO" Then
            Exit Sub
        Else
            Dim row As DataRow = ds.Tables("DelOutwardRetrocede").NewRow
            row("R_NO") = TempDel
            ds.Tables("DelOutwardRetrocede").Rows.Add(row)
        End If
        ds.Tables("OutwardRetrocede").Rows.RemoveAt(CInt(ArrayToString(AdvBandedGridView1.GetSelectedRows())))
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If CheckData() = False Then Exit Sub
        Select Case Label23.Text
            Case "RetrocedeAddEdit"
                If Edit = False Then
                    SaveNew()
                Else
                    SaveEdit()
                End If
            Case "RetrocedeCheck"
                SaveCheck()
            Case "RetrocedeAccountCheck"
                SaveAccCheck()
        End Select
        'If MTypeName = "RetrocedeAddEdit" Then
        '    If Edit = False Then
        '        SaveNew()
        '    Else
        '        SaveEdit()
        '    End If
        'ElseIf MTypeName = "RetrocedeCheck" Then
        '    SaveCheck()
        'ElseIf MTypeName = "RetrocedeAccountCheck" Then
        '    SaveAccCheck()
        'End If
    End Sub
    Private Sub SaveAccCheck()
        Dim ac As New OutwardRetrocedeControl
        Dim ai As New OutwardRetrocedeInfo
        Dim i As Integer
        For i = 0 To ds.Tables("OutwardRetrocede").Rows.Count - 1

            ai.R_RetrocedeNO = txtPMID.Text
            ai.R_AccountCheck = CheckEdit2.Checked
            ai.R_AccountCheckType = ComboBoxEdit1.Text
            ai.R_AccountCheckDate = DateEdit3.Text
            ai.R_AccountAction = DateEdit3.Text
            ai.R_AccountCheckRemark = MemoEdit2.Text

            ac.OutwardRetrocede_UpdateAccCheck(ai)
        Next
        MsgBox("會計部審核狀態已改變,單號: " & txtPMID.Text & " ")
        Me.Close()
    End Sub
    Private Sub SaveCheck()
        Dim ac As New OutwardRetrocedeControl
        Dim ai As New OutwardRetrocedeInfo
        Dim spc As New SharePurchaseController
        Dim spi As New SharePurchaseInfo
        Dim oac As New OutwardAcceptanceControl
        Dim oi As New OutwardInfo


        ai.R_RetrocedeNO = txtPMID.Text
        ai.R_Check = CheckEdit1.Checked
        ai.R_CheckType = CBA_CheckType.Text
        ai.R_CheckDate = DateEdit2.Text
        ai.R_CheckAction = InUserID
        ai.R_CheckRemark = MemoEdit1.Text

        If CheckEdit1.Checked = False Then
            ai.R_Detail = "暫退"

        ElseIf CheckEdit1.Checked = True Then
            ai.R_Detail = "已退"

        End If
        ac.OutwardRetrocede_UpdateCheck(ai)

        Dim i As Integer
        For i = 0 To ds.Tables("OutwardRetrocede").Rows.Count - 1

            spi.WH_ID = ButtonEdit1.Text
            spi.M_Code = ds.Tables("OutwardRetrocede").Rows(i)("M_Code")

            Dim Qty As Single
            Dim wi As LFERP.Library.WareHouse.WareInventory.WareInventoryInfo
            Dim wc As New LFERP.Library.WareHouse.WareInventory.WareInventoryMTController
            wi = wc.WareInventory_GetSub(ds.Tables("OutwardRetrocede").Rows(i)("M_Code"), ButtonEdit1.EditValue)

            If wi Is Nothing Then
                Qty = 0
            Else
                Qty = wi.WI_Qty
            End If

            If CheckEdit1.Checked = False Then
                'spi.WI_Qty = ds.Tables("OutwardRetrocede").Rows(i)("R_Qty")
                spi.WI_Qty = Qty + CSng(ds.Tables("OutwardRetrocede").Rows(i)("R_Qty"))
            Else
                'spi.WI_Qty = "-" & ds.Tables("OutwardRetrocede").Rows(i)("R_Qty")
                spi.WI_Qty = Qty - CSng(ds.Tables("OutwardRetrocede").Rows(i)("R_Qty"))
            End If

            'spc.UpdateWareInventory_WIQty(spi) '改倉庫數量

            spc.UpdateWareInventory_WIQty2(spi)

            oi.O_NO = ds.Tables("OutwardRetrocede").Rows(i)("O_NO")
            oi.M_Code = ds.Tables("OutwardRetrocede").Rows(i)("M_Code")
            oac.Outward_UpdateNoSendQty(oi)    '外发未交貨數加减
        Next
        MsgBox("審核狀態已改變,單號: " & txtPMID.Text & " ")
        Me.Close()

    End Sub
    Private Sub SaveNew()
        Dim R_RetrocedeNO As String
        Dim ac As New OutwardRetrocedeControl
        Dim ai As New OutwardRetrocedeInfo
        R_RetrocedeNO = GetRetrocedeNO()

        For i As Integer = 0 To ds.Tables("OutwardRetrocede").Rows.Count - 1
            ai.R_RetrocedeNO = R_RetrocedeNO '退貨單

            ai.WH_ID = ButtonEdit1.Text
            ai.S_Supplier = gluSupplier.EditValue
            ai.A_AcceptanceNO = ds.Tables("OutwardRetrocede").Rows(i)("A_AcceptanceNO")

            ai.M_Code = ds.Tables("OutwardRetrocede").Rows(i)("M_Code")
            ai.R_ReturnDate = DateEdit1.Text
            ai.R_Ver = Label2.Text
            ai.R_Action = Label3.Text

            ds.Tables("OutwardRetrocede").Rows(i)("R_NO") = GetR_NO()
            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_NO")) Then
                ai.R_NO = Nothing
            Else
                ai.R_NO = ds.Tables("OutwardRetrocede").Rows(i)("R_NO")

            End If
            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("M_Unit")) Then
                ai.M_Unit = Nothing
            Else
                ai.M_Unit = ds.Tables("OutwardRetrocede").Rows(i)("M_Unit")
            End If

            ai.M_Name = ds.Tables("OutwardRetrocede").Rows(i)("M_Name")

            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("M_Gauge")) Then
                ai.M_Gauge = Nothing
            Else
                ai.M_Gauge = ds.Tables("OutwardRetrocede").Rows(i)("M_Gauge")
            End If

            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("OS_BatchID")) Then
                ai.OS_BatchID = Nothing
            Else
                ai.OS_BatchID = ds.Tables("OutwardRetrocede").Rows(i)("OS_BatchID")
            End If



            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("PM_M_Code")) Then
                ai.PM_M_Code = Nothing
            Else
                ai.PM_M_Code = ds.Tables("OutwardRetrocede").Rows(i)("PM_M_Code")
            End If


            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("A_SendNO")) Then
                ai.A_SendNO = Nothing
            Else
                ai.A_SendNO = ds.Tables("OutwardRetrocede").Rows(i)("A_SendNO")
            End If


            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_Qty")) Then
                ai.R_Qty = "0"
            Else
                ai.R_Qty = ds.Tables("OutwardRetrocede").Rows(i)("R_Qty")
            End If


            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_Reason")) Then
                ai.R_Reason = Nothing
            Else
                ai.R_Reason = ds.Tables("OutwardRetrocede").Rows(i)("R_Reason")
            End If

            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_ReturnType")) Then
                ai.R_ReturnType = Nothing
            Else
                ai.R_ReturnType = ds.Tables("OutwardRetrocede").Rows(i)("R_ReturnType")
            End If

            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_Detail")) Then
                ai.R_Detail = Nothing
            Else
                ai.R_Detail = ds.Tables("OutwardRetrocede").Rows(i)("R_Detail")
            End If

            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("O_NO")) Then
                ai.O_NO = Nothing
            Else
                ai.O_NO = ds.Tables("OutwardRetrocede").Rows(i)("O_NO")
            End If

            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_SendDate")) Then
                ai.R_SendDate = Nothing
            Else
                ai.R_SendDate = ds.Tables("OutwardRetrocede").Rows(i)("R_SendDate")
            End If

            If txtRemark.Text = "" Then
                ai.R_RemarkT = Nothing
            Else
                ai.R_RemarkT = txtRemark.Text
            End If
            ai.R_Detail = "暫退"
            ai.R_UpdateDate = Format(Now, "yyyy/MM/dd")

            ac.OutwardRetrocede_Add(ai)

            Dim ac2 As New OutwardAcceptanceControl
            Dim aci2 As New OutwardAcceptanceInfo
            aci2.A_AcceptanceNO = ds.Tables("OutwardRetrocede").Rows(i)("A_AcceptanceNO").ToString

            aci2.A_Detail = "退貨未處理"

            ac2.OutwardAcceptance_UpdateDetail(aci2)
        Next

        MsgBox("已保存,單號: " & R_RetrocedeNO & " ")
        Me.Close()

    End Sub
    Private Function GetRetrocedeNO() As String
        Dim orc As New OutwardRetrocedeControl
        Dim ori As New OutwardRetrocedeInfo
        Dim strA As String, strB As String
        strA = Mid(CStr(Year(Now)), 3)
        If CInt(Month(Now)) < 10 Then
            strB = "0" & Month(Now)
        Else
            strB = Month(Now)
        End If
        Dim str As String = strA & strB
        ori = orc.OutwardRetrocede_GetNO(str)
        If ori Is Nothing Then
            GetRetrocedeNO = "R" & str & "0001"
        Else
            GetRetrocedeNO = "R" & str & Mid(CInt(Mid(ori.R_RetrocedeNO, 6) + 10001), 2)
        End If
    End Function
    Private Function GetR_NO() As String
        Dim orc As New OutwardRetrocedeControl
        Dim ori As New OutwardRetrocedeInfo
        'Dim oriL As New List(Of OutwardRetrocedeInfo)
        'oriL = orc.OutwardRetrocede_GetList(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        ori = orc.OutwardRetrocede_RNO("R")
        If ori Is Nothing Then
            GetR_NO = "R00000001"
        Else
            GetR_NO = "R" & Mid(CInt(Mid(ori.R_NO, 2)) + 100000001, 2)
        End If

    End Function
    Private Sub SaveEdit()
        Dim orc As New OutwardRetrocedeControl
        Dim ori As New OutwardRetrocedeInfo
        For i As Integer = 0 To ds.Tables("OutwardRetrocede").Rows.Count - 1

            ori.R_RetrocedeNO = Trim(txtPMID.Text)
            ori.WH_ID = ButtonEdit1.Text
            ori.S_Supplier = gluSupplier.EditValue
            ori.A_AcceptanceNO = ds.Tables("OutwardRetrocede").Rows(i)("A_AcceptanceNO")
            ori.M_Code = ds.Tables("OutwardRetrocede").Rows(i)("M_Code")
            ori.R_ReturnDate = DateEdit1.Text
            ori.R_Ver = Label2.Text
            ori.R_Action = Label3.Text

            If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_NO")) Then '新增
                ori.R_NO = GetR_NO()
                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("M_Unit")) Then
                    ori.M_Unit = Nothing
                Else
                    ori.M_Unit = ds.Tables("OutwardRetrocede").Rows(i)("M_Unit")
                End If

                ori.M_Name = ds.Tables("OutwardRetrocede").Rows(i)("M_Name")

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("M_Gauge")) Then
                    ori.M_Gauge = Nothing
                Else
                    ori.M_Gauge = ds.Tables("OutwardRetrocede").Rows(i)("M_Gauge")
                End If

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("OS_BatchID")) Then
                    ori.OS_BatchID = Nothing
                Else
                    ori.OS_BatchID = ds.Tables("OutwardRetrocede").Rows(i)("OS_BatchID")
                End If



                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("PM_M_Code")) Then
                    ori.PM_M_Code = Nothing
                Else
                    ori.PM_M_Code = ds.Tables("OutwardRetrocede").Rows(i)("PM_M_Code")
                End If


                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("A_SendNO")) Then
                    ori.A_SendNO = Nothing
                Else
                    ori.A_SendNO = ds.Tables("OutwardRetrocede").Rows(i)("A_SendNO")
                End If


                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_Qty")) Then
                    ori.R_Qty = "0"
                Else
                    ori.R_Qty = ds.Tables("OutwardRetrocede").Rows(i)("R_Qty")
                End If


                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_Reason")) Then
                    ori.R_Reason = Nothing
                Else
                    ori.R_Reason = ds.Tables("OutwardRetrocede").Rows(i)("R_Reason")
                End If

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_ReturnType")) Then
                    ori.R_ReturnType = Nothing
                Else
                    ori.R_ReturnType = ds.Tables("OutwardRetrocede").Rows(i)("R_ReturnType")
                End If

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_Detail")) Then
                    ori.R_Detail = Nothing
                Else
                    ori.R_Detail = ds.Tables("OutwardRetrocede").Rows(i)("R_Detail")
                End If

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("O_NO")) Then
                    ori.O_NO = Nothing
                Else
                    ori.O_NO = ds.Tables("OutwardRetrocede").Rows(i)("O_NO")
                End If

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_SendDate")) Then
                    ori.R_SendDate = Nothing
                Else
                    ori.R_SendDate = ds.Tables("OutwardRetrocede").Rows(i)("R_SendDate")
                End If

                If txtRemark.Text = "" Then
                    ori.R_RemarkT = Nothing
                Else
                    ori.R_RemarkT = txtRemark.Text
                End If

                ori.R_UpdateDate = Format(Now, "yyyy/MM/dd")

                orc.OutwardRetrocede_Add(ori)
            ElseIf Not IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_NO")) Then '修改

                ori.R_NO = ds.Tables("OutwardRetrocede").Rows(i)("R_NO")
                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("M_Unit")) Then
                    ori.M_Unit = Nothing
                Else
                    ori.M_Unit = ds.Tables("OutwardRetrocede").Rows(i)("M_Unit")
                End If

                ori.M_Name = ds.Tables("OutwardRetrocede").Rows(i)("M_Name")

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("M_Gauge")) Then
                    ori.M_Gauge = Nothing
                Else
                    ori.M_Gauge = ds.Tables("OutwardRetrocede").Rows(i)("M_Gauge")
                End If

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("OS_BatchID")) Then
                    ori.OS_BatchID = Nothing
                Else
                    ori.OS_BatchID = ds.Tables("OutwardRetrocede").Rows(i)("OS_BatchID")
                End If



                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("PM_M_Code")) Then
                    ori.PM_M_Code = Nothing
                Else
                    ori.PM_M_Code = ds.Tables("OutwardRetrocede").Rows(i)("PM_M_Code")
                End If


                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("A_SendNO")) Then
                    ori.A_SendNO = Nothing
                Else
                    ori.A_SendNO = ds.Tables("OutwardRetrocede").Rows(i)("A_SendNO")
                End If


                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_Qty")) Then
                    ori.R_Qty = "0"
                Else
                    ori.R_Qty = ds.Tables("OutwardRetrocede").Rows(i)("R_Qty")
                End If


                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_Reason")) Then
                    ori.R_Reason = Nothing
                Else
                    ori.R_Reason = ds.Tables("OutwardRetrocede").Rows(i)("R_Reason")
                End If

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_ReturnType")) Then
                    ori.R_ReturnType = Nothing
                Else
                    ori.R_ReturnType = ds.Tables("OutwardRetrocede").Rows(i)("R_ReturnType")
                End If

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_Detail")) Then
                    ori.R_Detail = Nothing
                Else
                    ori.R_Detail = ds.Tables("OutwardRetrocede").Rows(i)("R_Detail")
                End If

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("O_NO")) Then
                    ori.O_NO = Nothing
                Else
                    ori.O_NO = ds.Tables("OutwardRetrocede").Rows(i)("O_NO")
                End If

                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_SendDate")) Then
                    ori.R_SendDate = Nothing
                Else
                    ori.R_SendDate = ds.Tables("OutwardRetrocede").Rows(i)("R_SendDate")
                End If

                If txtRemark.Text = "" Then
                    ori.R_RemarkT = Nothing
                Else
                    ori.R_RemarkT = txtRemark.Text
                End If

                ori.R_UpdateDate = Format(Now, "yyyy/MM/dd")
                orc.OutwardRetrocede_Update(ori)
            End If
        Next
        MsgBox("已保存,單號: " & txtPMID.Text & " ")
        Me.Close()

    End Sub
    Private Function CheckData() As Boolean
        CheckData = False
        If Label23.Text = "RetrocedeAddEdit" Then

            If ButtonEdit1.Text = "" Or DateEdit1.Text = "" Then
                MsgBox("請填寫退貨日期及退貨倉庫")
                Exit Function
            End If

            If ds.Tables("OutwardRetrocede").Rows.Count = 0 Then
                MsgBox("沒有數據,無法保存!")
                Exit Function
            End If
            For i As Integer = 0 To ds.Tables("OutwardRetrocede").Rows.Count - 1
                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_SendDate")) Then
                    MsgBox("請填寫交回日期!")
                    Exit Function
                End If
                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_Qty")) Then
                    MsgBox("請填寫退貨數量!")
                    Exit Function
                End If
                If IsDBNull(ds.Tables("OutwardRetrocede").Rows(i)("R_ReturnType")) Then
                    MsgBox("請填寫退貨類型!")
                    Exit Function
                End If
            Next
        ElseIf Label23.Text = "RetrocedeCheck" Then
            If CheckEdit1.Checked = False Then
                If OldCheckA = False Then
                    MsgBox("請先更改審核狀態,才能保存!", MsgBoxStyle.OkOnly)
                    Exit Function
                End If
            End If
            If CheckEdit1.Checked = True Then
                If OldCheckA = True Then
                    MsgBox("請先更改審核狀態,才能保存!", MsgBoxStyle.OkOnly)
                    Exit Function
                End If
            End If
            If CBA_CheckType.Text = "" Then
                MsgBox("請填寫審核類型,才能保存!", MsgBoxStyle.OkOnly)
                Exit Function
            End If
        ElseIf Label23.Text = "RetrocedeAccountCheck" Then
            If CheckEdit2.Checked = False Then
                If OldCheckB = False Then
                    MsgBox("請先更改復核狀態,才能保存!", MsgBoxStyle.OkOnly)
                    Exit Function
                End If
            End If
            If CheckEdit2.Checked = True Then
                If OldCheckB = True Then
                    MsgBox("請先更改復核狀態,才能保存!", MsgBoxStyle.OkOnly)
                    Exit Function
                End If
            End If

            If ComboBoxEdit1.Text = "" Then
                MsgBox("請填寫復核類型,才能保存!", MsgBoxStyle.OkOnly)
                Exit Function
            End If
        End If
        CheckData = True
    End Function

End Class