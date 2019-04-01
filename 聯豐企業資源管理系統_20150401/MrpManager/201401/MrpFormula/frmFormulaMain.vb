Imports System
Imports LFERP.SystemManager
Imports LFERP.Library.MrpManager.MrpFormula
Imports System.Collections.Specialized
Imports System.Math
Imports Microsoft.VisualBasic
Public Class frmFormulaMain
    Dim ds As New DataSet
    Dim MFC As New MRPFormulaController
    Private _flag As Boolean
    Property Flag() As Boolean '屬性
        Get
            Return _flag
        End Get
        Set(ByVal value As Boolean)
            _flag = value
        End Set
    End Property

    '''' <summary>
    '''' 拖動數據
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub TVwGS_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs)
    '    On Error Resume Next
    '    If TVwFiled.SelectedNode.Level = 1 Then
    '        TVwFiled.DoDragDrop(TVwFiled.SelectedNode.Text, DragDropEffects.All)
    '    End If
    'End Sub

    'Private Sub TVwCalr_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs)
    '    On Error Resume Next
    '    If TVwCalr.SelectedNode.Level = 1 Then
    '        TVwCalr.DoDragDrop(TVwCalr.SelectedNode.Text, DragDropEffects.All)
    '    End If
    'End Sub
    ''' <summary>
    ''' 點擊公式名--獲得公式信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GridView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridView3.Click
        On Error Resume Next
        If GridView3.RowCount <= 0 Then
            Exit Sub
        End If
        If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "FormulaName") Is DBNull.Value Then
            txtformula.Text = String.Empty
            RichTextBoxFormula.Text = String.Empty
            chkUsed.Checked = False
        Else
            txtformula.Text = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "FormulaName")
            RichTextBoxFormula.Text = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Formula_CH")
            chkUsed.Checked = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "InCheck")
        End If
    End Sub
    ''' <summary>
    ''' 載入信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmFormulaMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TVWFiled.ExpandAll()
        'TVwCalr.ExpandAll()
        'TVwCalr.Nodes(0).Nodes(4).ToolTipText = "四舍五入.如" & vbCrLf & "RoundEx(1.2345,0)=1" & vbCrLf & "RoundEx(1.2345,3)=1.235"
        TreeList1.ExpandAll()
        TreeList2.ExpandAll()
        CreateTable()
        LoadTable()
    End Sub
    ''' <summary>
    ''' 綁定點擊事件--主要實現↑↓操作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        GridView1_Click(Nothing, Nothing)
    End Sub
    '''' <summary>
    '''' 雙擊加入字段
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub TVWFiled_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If TVWFiled.SelectedNode.Level = 1 Then
    '        InsertStrToText(RichTextBoxFormula, TVWFiled.SelectedNode.Text, False)
    '    End If
    'End Sub
    'Private Sub TVwCalr_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If TVwCalr.SelectedNode.Level = 1 Then
    '        InsertStrToText(RichTextBoxFormula, TVwCalr.SelectedNode.Text, False)
    '    End If
    'End Sub
    ''' <summary>
    ''' 插入字段到光標停留的位置
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="astrValue"></param>
    ''' <param name="ablnLf"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InsertStrToText(ByVal obj As Object, ByVal astrValue As String, Optional ByVal ablnLf As Boolean = False) As String
        InsertStrToText = ""
        Dim lngPos As Long
        lngPos = obj.SelectionStart
        If lngPos > 0 And ablnLf = False Then
            obj.Text = Microsoft.VisualBasic.Left(obj.Text.ToString, lngPos) & astrValue & Mid(obj.Text, lngPos + 1)
        ElseIf ablnLf = True Then
            obj.Text = astrValue & vbCrLf & obj.Text
        Else
            obj.Text = astrValue & obj.Text
        End If
        obj.Focus()
        If ablnLf = False Then
            obj.SelectionStart = lngPos + Len(astrValue)
        Else
            obj.SelectionStart = lngPos + Len(astrValue & vbCrLf)
        End If
    End Function
    ''' <summary>
    ''' 創建公式臨時表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateTable()
        ds.Tables.Clear()
        With ds.Tables.Add("FormulaTb")
            .Columns.Add("AutoID", GetType(String))
            .Columns.Add("FormulaID", GetType(String))
            .Columns.Add("FormulaName", GetType(String))
            .Columns.Add("Formula_CH", GetType(String))
            .Columns.Add("InCheck", GetType(Boolean))
        End With
        gridformula.DataSource = ds.Tables("FormulaTb")
    End Sub
    ''' <summary>
    ''' 在表中載入數據
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadTable()
        Dim Row As DataRow
        On Error Resume Next
        Dim perList As New List(Of MRPFormulaInfo)
        perList = MFC.MRPFormula_GetList
        If perList.Count > 0 Then
            For i As Integer = 0 To perList.Count - 1
                Row = ds.Tables("FormulaTb").NewRow
                Row("AutoID") = perList(i).AutoID
                Row("FormulaID") = perList(i).FormulaID
                Row("FormulaName") = perList(i).FormulaName
                Row("Formula_CH") = perList(i).Formula_CH
                Row("InCheck") = perList(i).InCheck
                ds.Tables("FormulaTb").Rows.Add(Row)
            Next i
        End If
    End Sub
    ''' <summary>
    ''' 右鍵添加公式
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim row As DataRow
        row = ds.Tables("FormulaTb").NewRow
        row("FormulaName") = DBNull.Value
        row("AutoID") = DBNull.Value
        'row("FormulaID") = Nothing
        'row("Formula") = Nothing
        ds.Tables("FormulaTb").Rows.Add(row)
    End Sub
    ''' <summary>
    ''' 重置信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRes.Click
        'RichTextBoxFormula.Undo()
        'RichTextBoxFormula.Redo()
        RichTextBoxFormula.Text = String.Empty
    End Sub
    ''' <summary>
    ''' 修改或添加公式
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error Resume Next
        strMsg = ""
        CheckFormula()
        If strMsg = "" Then
            Dim MFI As New MRPFormulaInfo
            With ds.Tables("FormulaTb")
                MFI.FormulaName = txtformula.Text
                MFI.AutoID = IIf(IsDBNull(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "AutoID")), 0, GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "AutoID"))
                MFI.Formula_CH = RichTextBoxFormula.Text
                MFI.CreateUserID = InUserID
                MFI.CreateDate = System.DateTime.Now
                MFI.ModifyUserID = InUserID
                MFI.ModifyDate = System.DateTime.Now
                MFI.InCheck = chkUsed.Checked
                If GetFormulaNameList() Then
                    If MsgBox("確認修改公式：" & "'" & txtformula.Text & "'" & "么？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If MFC.MRPFormula_Update(MFI) = False Then
                            MsgBox("保存失敗，請檢查原因", 60, "提示")
                            Exit Sub
                        Else
                            frmFormulaMain_Load(Nothing, Nothing)
                        End If
                    End If
                Else
                    If txtformula.Text <> "" Then
                        If MsgBox("確認添加公式：" & "'" & txtformula.Text & "'" & "么？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            If MFC.MRPFormula_Add(MFI) = False Then
                                MsgBox("保存失敗，請檢查原因", 60, "提示")
                                Exit Sub
                            Else
                                'MemoEdit1.Text = GetFormula_EN()
                                frmFormulaMain_Load(Nothing, Nothing)
                            End If
                        End If
                    Else
                        MsgBox("公式名稱為空！不能保存！", 60, "提示")
                        Exit Sub
                    End If
                End If
            End With
        Else
            MsgBox("保存失敗，請檢查原因", 60, "提示")
        End If
    End Sub
    ''' <summary>
    ''' 綁定點擊事件--主要實現動態獲得用戶新增的公式名稱
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView3.CellValueChanged
        GridView1_Click(Nothing, Nothing)
    End Sub
    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' 檢查
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncheck.Click
        strMsg = ""
        CheckFormula()
        If strMsg <> "" Then
        Else
            'Labelxx.Text = results(0)
            MsgBox("公式無誤!", 60, "提示")
        End If
    End Sub

    Private Sub RichTextBoxFormula_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RichTextBoxFormula.DragDrop
        'RichTextBoxFormula.DoDragDrop("11111", DragDropEffects.All)
        'Dim treelist As New DevExpress.XtraTreeList.TreeList
        'treelist = sender

        If Flag Then
            InsertStrToText(RichTextBoxFormula, TreeList1.FocusedNode.GetValue(0), False)
            Flag = False
        Else
            InsertStrToText(RichTextBoxFormula, TreeList2.FocusedNode.GetValue(0), False)
        End If


    End Sub
    ''' <summary>
    ''' 設置關鍵字顏色
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RichTextBoxFormula_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBoxFormula.TextChanged
        If RichTextBoxFormula.Text = "" Then Exit Sub
        'Dim StrAarray As Array = Split("毛需求量,庫存數量,在途數量,待驗量,生產未領,最低庫存,訂貨批量,經濟批量,最大訂購量,最小訂購量", ",") '任意添加关键字。 
        Dim StrAarray As Array = Split("+,-,*,/,%,RoundEx(),(,)", ",") '任意添加关键字。 
        Dim l As Long, T, TS As String, d As Long
        T = RichTextBoxFormula.Text
        d = RichTextBoxFormula.SelectionStart
        RichTextBoxFormula.SelectionStart = 0
        RichTextBoxFormula.SelectionLength = Len(T)
        RichTextBoxFormula.SelectionColor = Color.Black
        For i As Integer = 0 To UBound(StrAarray)
            TS = Trim(StrAarray(i))
            l = InStr(1, T, StrAarray(i), CompareMethod.Text)
            If l = 0 Then GoTo n
            RichTextBoxFormula.SelectionStart = l - 1
            RichTextBoxFormula.SelectionLength = Len(TS)
            RichTextBoxFormula.SelectionColor = Color.Blue
            RichTextBoxFormula.SelectionStart = l + Len(TS) - 1
            RichTextBoxFormula.SelectionColor = Color.Black
            Do Until l = 0
                l = InStr(l + 1, T, StrAarray(i), CompareMethod.Text)
                If l = 0 Then Exit Do
                RichTextBoxFormula.SelectionStart = l - 1
                RichTextBoxFormula.SelectionLength = Len(TS)
                RichTextBoxFormula.SelectionColor = Color.Blue
                RichTextBoxFormula.SelectionStart = l + Len(TS) - 1
                RichTextBoxFormula.SelectionColor = Color.Black
            Loop
n:      Next
        RichTextBoxFormula.SelectionStart = d
        RichTextBoxFormula.SelectionLength = 0
        Return
    End Sub
    ''' <summary>
    ''' 刪除公式
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        On Error Resume Next
        Dim a As String = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "AutoID").ToString
        If GridView3.RowCount > 0 Then
            If MsgBox("確認刪除公式：" & "'" & txtformula.Text & "'" & "么？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "AutoID").ToString = String.Empty Then
                    ds.Tables("FormulaTb").Rows.RemoveAt(GridView3.FocusedRowHandle)
                Else
                    If MFC.MRPFormula_Delete(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "AutoID")) Then
                        ds.Tables("FormulaTb").Rows.RemoveAt(GridView3.FocusedRowHandle)
                    End If
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 檢查公式
    ''' </summary>
    ''' <remarks></remarks>
    Sub CheckFormula()
        On Error Resume Next
        Dim expression As String = RichTextBoxFormula.Text
        Dim parameters As NameValueCollection = New NameValueCollection()
        parameters.Add("毛需求量", "80")   '其下為測試數據
        parameters.Add("庫存數量", "20")
        parameters.Add("在途數量", "10")
        parameters.Add("待驗量", "5")
        parameters.Add("生產未領", "15")
        parameters.Add("退貨數量", "25")
        parameters.Add("安全庫存", "35")
        parameters.Add("最低庫存", "45")
        parameters.Add("訂貨批量", "55")
        parameters.Add("經濟批量", "65")
        parameters.Add("最大訂購量", "75")
        parameters.Add("最小訂購量", "85")
        Dim results() As Decimal = Calculator.Eval(expression, parameters)
    End Sub
    '    ''' <summary>
    '    ''' 获得英文字段版公式
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Private Function GetFormula_EN() As String
    '        If RichTextBoxFormula.Text = "" Then Return String.Empty
    '        Dim StrAarray As Array = Split("毛需求量,庫存數量,在途數量,待驗量,生產未領,退貨數量,安全庫存,最低庫存,訂貨批量,經濟批量,最大訂購量,最小訂購量,+,-,*,/,%,RoundEx(),(,)", ",") '任意添加关键字。 
    '        '        Dim l As Long, T, TS As String, d As Long
    '        '        T = RichTextBoxFormula.Text
    '        '        d = RichTextBoxFormula.SelectionStart
    '        '        RichTextBoxFormula.SelectionStart = 0
    '        '        RichTextBoxFormula.SelectionLength = 100
    '        '        'RichTextBoxFormula.SelectionLength = Len(T)
    '        '        RichTextBoxFormula.SelectionColor = Color.Black
    '        '        For i As Integer = 0 To UBound(StrAarray)
    '        '            TS = Trim(StrAarray(i))
    '        '            l = InStr(1, T, StrAarray(i), CompareMethod.Text)
    '        '            If l = 0 Then GoTo n
    '        '            RichTextBoxFormula.SelectionStart = l - 1
    '        '            RichTextBoxFormula.SelectionLength = Len(TS)
    '        '            Select Case TS
    '        '                Case "毛需求量"
    '        '                    RichTextBoxFormula.SelectedText = "MP_NeedQty"
    '        '                    TS = "MP_NeedQty"
    '        '                Case "庫存數量"
    '        '                    RichTextBoxFormula.SelectedText = "MP_InventoryQty"
    '        '                    TS = "MP_InventoryQty"
    '        '                Case "在途數量"
    '        '                    RichTextBoxFormula.SelectedText = "MP_InTransitQty"
    '        '                    TS = "MP_InTransitQty"
    '        '                Case "待驗量"
    '        '                    RichTextBoxFormula.SelectedText = "MP_Inspection"
    '        '                    TS = "MP_Inspection"
    '        '                Case "生產未領"
    '        '                    RichTextBoxFormula.SelectedText = "MP_NoCollar"
    '        '                    TS = "MP_NoCollar"
    '        '                Case "退貨數量"
    '        '                    RichTextBoxFormula.SelectedText = "MP_RetreatQty"
    '        '                    TS = "MP_RetreatQty"
    '        '                Case "安全庫存"
    '        '                    RichTextBoxFormula.SelectedText = "MP_SecInv"
    '        '                    TS = "MP_SecInv"
    '        '                Case "最低庫存"
    '        '                    RichTextBoxFormula.SelectedText = "MP_LowLimit"
    '        '                    TS = "MP_LowLimit"
    '        '                Case "訂貨批量"
    '        '                    RichTextBoxFormula.SelectedText = "MP_BatchQty"
    '        '                    TS = "MP_BatchQty"
    '        '                Case "經濟批量"
    '        '                    RichTextBoxFormula.SelectedText = "MP_BatFixEconomy"
    '        '                    TS = "MP_BatFixEconomy"
    '        '                Case "最大訂購量"
    '        '                    RichTextBoxFormula.SelectedText = "MP_OrderMax"
    '        '                    TS = "MP_OrderMax"
    '        '                Case "最小訂購量"
    '        '                    RichTextBoxFormula.SelectedText = "MP_OrderMin"
    '        '                    TS = "MP_OrderMin"
    '        '                Case Else
    '        '            End Select
    '        '            RichTextBoxFormula.SelectionStart = l + Len(TS) - 1
    '        '            RichTextBoxFormula.SelectionColor = Color.Black
    '        '            Do Until l = 0
    '        '                l = InStr(l + 1, T, StrAarray(i), CompareMethod.Text)
    '        '                If l = 0 Then Exit Do
    '        '                RichTextBoxFormula.SelectionStart = l - 1
    '        '                Select Case TS
    '        '                    Case "毛需求量"
    '        '                        RichTextBoxFormula.SelectedText = "MP_NeedQty"
    '        '                        TS = "MP_NeedQty"
    '        '                    Case "庫存數量"
    '        '                        RichTextBoxFormula.SelectedText = "MP_InventoryQty"
    '        '                        TS = "MP_InventoryQty"
    '        '                    Case "在途數量"
    '        '                        RichTextBoxFormula.SelectedText = "MP_InTransitQty"
    '        '                        TS = "MP_InTransitQty"
    '        '                    Case "待驗量"
    '        '                        RichTextBoxFormula.SelectedText = "MP_Inspection"
    '        '                        TS = "MP_Inspection"
    '        '                    Case "生產未領"
    '        '                        RichTextBoxFormula.SelectedText = "MP_NoCollar"
    '        '                        TS = "MP_NoCollar"
    '        '                    Case "退貨數量"
    '        '                        RichTextBoxFormula.SelectedText = "MP_RetreatQty"
    '        '                        TS = "MP_RetreatQty"
    '        '                    Case "安全庫存"
    '        '                        RichTextBoxFormula.SelectedText = "MP_SecInv"
    '        '                        TS = "MP_SecInv"
    '        '                    Case "最低庫存"
    '        '                        RichTextBoxFormula.SelectedText = "MP_LowLimit"
    '        '                        TS = "MP_LowLimit"
    '        '                    Case "訂貨批量"
    '        '                        RichTextBoxFormula.SelectedText = "MP_BatchQty"
    '        '                        TS = "MP_BatchQty"
    '        '                    Case "經濟批量"
    '        '                        RichTextBoxFormula.SelectedText = "MP_BatFixEconomy"
    '        '                        TS = "MP_BatFixEconomy"
    '        '                    Case "最大訂購量"
    '        '                        RichTextBoxFormula.SelectedText = "MP_OrderMax"
    '        '                        TS = "MP_OrderMax"
    '        '                    Case "最小訂購量"
    '        '                        RichTextBoxFormula.SelectedText = "MP_OrderMin"
    '        '                        TS = "MP_OrderMin"
    '        '                    Case Else
    '        '                End Select
    '        '                'RichTextBoxFormula.SelectedText = TS
    '        '                RichTextBoxFormula.SelectionLength = Len(TS)
    '        '                RichTextBoxFormula.SelectionStart = l + Len(TS) - 1
    '        '                RichTextBoxFormula.SelectionColor = Color.Black
    '        '            Loop
    '        'n:      Next
    '        '        'Next
    '        '        RichTextBoxFormula.SelectionStart = d
    '        '        RichTextBoxFormula.SelectionLength = 0
    '        '        Return RichTextBoxFormula.Text
    '        Dim l As Long, T, TS As String, d As Long
    '        T = RichTextBoxFormula.Text
    '        d = RichTextBoxFormula.SelectionStart
    '        RichTextBoxFormula.SelectionStart = 0
    '        RichTextBoxFormula.SelectionLength = Len(T)
    '        RichTextBoxFormula.SelectionColor = Color.Black
    '        For i As Integer = 0 To UBound(StrAarray)
    '            TS = Trim(StrAarray(i))
    '            Select Case TS
    '                Case "毛需求量"
    '                    RichTextBoxFormula.SelectedText = "MP_NeedQty"
    '                    TS = "MP_NeedQty"
    '                Case "庫存數量"
    '                    RichTextBoxFormula.SelectedText = "MP_InventoryQty"
    '                    TS = "MP_InventoryQty"
    '                Case "在途數量"
    '                    RichTextBoxFormula.SelectedText = "MP_InTransitQty"
    '                    TS = "MP_InTransitQty"
    '                Case "待驗量"
    '                    RichTextBoxFormula.SelectedText = "MP_Inspection"
    '                    TS = "MP_Inspection"
    '                Case "生產未領"
    '                    RichTextBoxFormula.SelectedText = "MP_NoCollar"
    '                    TS = "MP_NoCollar"
    '                Case "退貨數量"
    '                    RichTextBoxFormula.SelectedText = "MP_RetreatQty"
    '                    TS = "MP_RetreatQty"
    '                Case "安全庫存"
    '                    RichTextBoxFormula.SelectedText = "MP_SecInv"
    '                    TS = "MP_SecInv"
    '                Case "最低庫存"
    '                    RichTextBoxFormula.SelectedText = "MP_LowLimit"
    '                    TS = "MP_LowLimit"
    '                Case "訂貨批量"
    '                    RichTextBoxFormula.SelectedText = "MP_BatchQty"
    '                    TS = "MP_BatchQty"
    '                Case "經濟批量"
    '                    RichTextBoxFormula.SelectedText = "MP_BatFixEconomy"
    '                    TS = "MP_BatFixEconomy"
    '                Case "最大訂購量"
    '                    RichTextBoxFormula.SelectedText = "MP_OrderMax"
    '                    TS = "MP_OrderMax"
    '                Case "最小訂購量"
    '                    RichTextBoxFormula.SelectedText = "MP_OrderMin"
    '                    TS = "MP_OrderMin"
    '                Case Else
    '            End Select
    '            l = InStr(1, T, StrAarray(i), CompareMethod.Text)
    '            If l = 0 Then GoTo n
    '            RichTextBoxFormula.SelectionStart = l - 1
    '            RichTextBoxFormula.SelectionLength = Len(TS)
    '            RichTextBoxFormula.SelectionColor = Color.Blue
    '            RichTextBoxFormula.SelectionStart = l + Len(TS) - 1
    '            RichTextBoxFormula.SelectionColor = Color.Black
    '            Do Until l = 0
    '                l = InStr(l + 1, T, StrAarray(i), CompareMethod.Text)
    '                If l = 0 Then Exit Do
    '                RichTextBoxFormula.SelectionStart = l - 1
    '                RichTextBoxFormula.SelectionLength = Len(TS)
    '                RichTextBoxFormula.SelectionColor = Color.Blue
    '                RichTextBoxFormula.SelectionStart = l + Len(TS) - 1
    '                RichTextBoxFormula.SelectionColor = Color.Black
    '            Loop
    'n:      Next
    '        RichTextBoxFormula.SelectionStart = d
    '        RichTextBoxFormula.SelectionLength = 0
    '        Return RichTextBoxFormula.Text
    '    End Function
    ''' <summary>
    ''' 獲得公式名集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFormulaNameList() As Boolean
        Dim perList As New List(Of MRPFormulaInfo)
        perList = MFC.MRPFormula_GetList
        Dim StrList As New List(Of String)
        If txtformula.Text.Length > 0 Then
            For i As Integer = 0 To perList.Count - 1
                StrList.Add(perList(i).FormulaName)
            Next i
        End If
        For i As Integer = 0 To perList.Count - 1
            If StrList(i) = txtformula.Text Then
                Return True
            End If
        Next
        Return False
    End Function
    ''' <summary>
    ''' 雙擊加入運算字段
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TreeList1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeList1.DoubleClick
        If TreeList1.Nodes.Count <> 0 Then
            InsertStrToText(RichTextBoxFormula, TreeList1.FocusedNode.GetValue(0), False)
        End If
    End Sub
    ''' <summary>
    ''' 雙擊加入運算符
    ''' </summary>訂貨批量
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TreeList2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeList2.DoubleClick
        If TreeList2.Nodes.Count <> 0 Then
            InsertStrToText(RichTextBoxFormula, TreeList2.FocusedNode.GetValue(0), False)
        End If
    End Sub
    Private Sub TreeList1_DragLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeList1.DragLeave
        Flag = True
    End Sub

    'Private Sub TreeList2_DragLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeList2.DragLeave
    '    Flag = False
    'End Sub

    'Private Sub TreeList1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeList1.DragDrop
    '    TreeList1.DoDragDrop(TreeList1.FocusedNode.GetValue("字段名"), DragDropEffects.All)
    'End Sub

    'Private Sub TreeList1_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeList1.DragEnter
    '    'TreeList1.DoDragDrop(TreeList1.FocusedNode.GetValue("字段名"), DragDropEffects.All)
    'End Sub

End Class