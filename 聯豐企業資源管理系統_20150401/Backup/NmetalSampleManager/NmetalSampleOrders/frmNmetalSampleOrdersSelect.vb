Imports LFERP.DataSetting
Imports LFERP.Library.NmetalSampleManager.NmetalSampleOrdersMain
Public Class frmNmetalSampleOrdersSelect
    Dim socon As New NmetalSampleOrdersMainControler
    Private _SO_ID As String
    'Private _PM_M_Code As String
    Private _SS_Edition As String
    'Private _SO_OrderQty As Integer
    Private intSO_NoSendQty As Integer
    Private intSO_OrderQty As Integer

    Property SO_ID() As String '属性
        Get
            Return _SO_ID
        End Get
        Set(ByVal value As String)
            _SO_ID = value
        End Set
    End Property
    'Property PM_M_Code() As String '属性
    '    Get
    '        Return _PM_M_Code
    '    End Get
    '    Set(ByVal value As String)
    '        _PM_M_Code = value
    '    End Set
    'End Property
    Property SS_Edition() As String '属性
        Get
            Return _SS_Edition
        End Get
        Set(ByVal value As String)
            _SS_Edition = value
        End Set
    End Property
    'Property SO_OrderQty() As Integer  '属性
    '    Get
    '        Return _SO_OrderQty
    '    End Get
    '    Set(ByVal value As Integer)
    '        _SO_OrderQty = value
    '    End Set
    'End Property
    Private Sub frmCustomerFeedbackSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim solist As New List(Of NmetalSampleOrdersMainInfo)
        solist = socon.NmetalSampleOrdersMain_GetList(SO_ID, Nothing, Nothing, Nothing, Nothing, Nothing, True)
        If solist.Count > 0 Then
            txtSO_ID.Text = SO_ID
            txtSS_Edition.Text = SS_Edition
            txtPM_M_Code.Text = solist(0).PM_M_Code
            txtSO_OrderQty.Text = solist(0).SO_OrderQty

            intSO_NoSendQty = solist(0).SO_NoSendQty
            intSO_OrderQty = solist(0).SO_OrderQty
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If txtSO_ID.Text = String.Empty Then
            MsgBox("訂單編號不能为空,请输入！", MsgBoxStyle.Information, "溫馨提示")
            Exit Sub
        End If
        If txtSS_Edition.Text = String.Empty Then
            MsgBox("版本號不能为空,请输入！", MsgBoxStyle.Information, "溫馨提示")
            Exit Sub
        End If
        If txtPM_M_Code.Text = String.Empty Then
            MsgBox("產品編號不能为空,请输入！", MsgBoxStyle.Information, "溫馨提示")
            Exit Sub
        End If
        If txtSO_OrderQty.Text = String.Empty Then
            MsgBox("原來數量不能为空,请输入！", MsgBoxStyle.Information, "溫馨提示")
            Exit Sub
        End If
        If txtQty.Text = String.Empty Then
            MsgBox("現數量不能为空,请输入！", MsgBoxStyle.Information, "溫馨提示")
            txtQty.Focus()
            Exit Sub
        End If
        '
        Dim soinfo As New NmetalSampleOrdersMainInfo
        soinfo.SO_ID = txtSO_ID.Text
        soinfo.SO_OrderQty = txtQty.Text
        soinfo.SS_Edition = SS_Edition
        '處理未交數量-------------------------------------
        If CInt(txtQty.Text) > intSO_OrderQty Then
            soinfo.SO_NoSendQty = intSO_NoSendQty + (CInt(txtQty.Text) - intSO_OrderQty)
        End If
        If CInt(txtQty.Text) < intSO_OrderQty Then
            soinfo.SO_NoSendQty = intSO_NoSendQty - (intSO_OrderQty - CInt(txtQty.Text))
        End If
        If CInt(txtQty.Text) = intSO_OrderQty Then
            soinfo.SO_NoSendQty = intSO_NoSendQty
        End If

        If socon.NmetalSampleOrdersMain_UpdateQty(soinfo) = False Then
            MsgBox("更改數量錯誤！", MsgBoxStyle.Information, "溫馨提示")
            Exit Sub
        End If
        MsgBox("更改數量完成！", MsgBoxStyle.Information, "溫馨提示")
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub
End Class