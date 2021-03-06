Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.Sql

Namespace LFERP.Library.NmetalSampleManager.NmetalSampleCollection
    Public Class NmetalSampleCollectionControler
        Public Function NmetalSampleCollection_Add(ByVal objinfo As NmetalSampleCollectionInfo) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_Add")

                db.AddInParameter(dbComm, "@Code_ID", DbType.String, objinfo.Code_ID)
                db.AddInParameter(dbComm, "@Qty", DbType.Int16, objinfo.Qty)
                db.AddInParameter(dbComm, "@StatusType", DbType.String, objinfo.StatusType)
                db.AddInParameter(dbComm, "@Remark", DbType.String, objinfo.Remark)
                db.AddInParameter(dbComm, "@PM_M_Code", DbType.String, objinfo.PM_M_Code)

                db.AddInParameter(dbComm, "@AddUserID", DbType.String, objinfo.AddUserID)
                db.AddInParameter(dbComm, "@AddDate", DbType.Date, objinfo.AddDate)
                db.AddInParameter(dbComm, "@PM_Type", DbType.String, objinfo.PM_Type)
                db.AddInParameter(dbComm, "@SO_ID", DbType.String, objinfo.SO_ID)
                db.AddInParameter(dbComm, "@SP_ID", DbType.String, objinfo.SP_ID)

                db.AddInParameter(dbComm, "@SS_Edition", DbType.String, objinfo.SS_Edition)
                db.AddInParameter(dbComm, "@BarcodeType", DbType.String, objinfo.BarcodeType)
                db.AddInParameter(dbComm, "@D_ID", DbType.String, objinfo.D_ID)
                db.AddInParameter(dbComm, "@BitAuto", DbType.Boolean, objinfo.BitAuto)
                db.AddInParameter(dbComm, "SO_Type", DbType.String, objinfo.SO_Type)

                db.AddInParameter(dbComm, "@TWeight", DbType.Decimal, objinfo.TWeight)
                db.AddInParameter(dbComm, "@RWeight", DbType.Decimal, objinfo.RWeight)
                db.AddInParameter(dbComm, "@IWeight", DbType.Decimal, objinfo.IWeight)

                db.AddInParameter(dbComm, "PS_NO", DbType.String, objinfo.PS_NO)
                db.ExecuteNonQuery(dbComm)
                NmetalSampleCollection_Add = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_Add = False
            End Try
        End Function

        Public Function NmetalSampleCollection_Update(ByVal objinfo As NmetalSampleCollectionInfo) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_Update")
                db.AddInParameter(dbComm, "@Remark", DbType.String, objinfo.Remark)
                db.AddInParameter(dbComm, "@PM_M_Code", DbType.String, objinfo.PM_M_Code)
                db.AddInParameter(dbComm, "@AddUserID", DbType.String, objinfo.AddUserID)
                db.AddInParameter(dbComm, "@AddDate", DbType.Date, objinfo.AddDate)
                db.AddInParameter(dbComm, "@ModifyUserID", DbType.String, objinfo.ModifyUserID)
                db.AddInParameter(dbComm, "@ModifyDate", DbType.DateTime, objinfo.ModifyDate)
                db.AddInParameter(dbComm, "@Code_ID", DbType.String, objinfo.Code_ID)

                db.AddInParameter(dbComm, "@PM_Type", DbType.String, objinfo.PM_Type)
                db.AddInParameter(dbComm, "@SO_ID", DbType.String, objinfo.SO_ID)
                db.AddInParameter(dbComm, "@SP_ID", DbType.String, objinfo.SP_ID)
                db.AddInParameter(dbComm, "@SS_Edition", DbType.String, objinfo.SS_Edition)
                db.AddInParameter(dbComm, "@BitAuto", DbType.Boolean, objinfo.BitAuto)

                db.ExecuteNonQuery(dbComm)
                NmetalSampleCollection_Update = True

            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_Update = False
            End Try
        End Function


        Public Function NmetalSampleCollection_Delete(ByVal Code_ID As String, ByVal AutoID As String) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_Delete")
                db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
                db.AddInParameter(dbComm, "@AutoID", DbType.String, AutoID)
                db.ExecuteNonQuery(dbComm)
                NmetalSampleCollection_Delete = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_Delete = False
            End Try
        End Function


        Public Function NmetalSampleCollection_DCGetlist(ByVal StatusType As String, ByVal Code_ID As String, ByVal AutoID As String, ByVal SO_ID As String, ByVal SS_Edition As String, ByVal SP_ID As String, ByVal ReportEmpty As Boolean, ByVal ClientBarcode As String, ByVal PM_M_Code As String, ByVal BarcodeType As String, ByVal D_ID As String, ByVal StartDate As String, ByVal EndDate As String, ByVal AddUserID As String, ByVal BitAuto As String) As DataTable
            Try
                Dim ds As New DataSet
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_Getlist")
                db.AddInParameter(dbComm, "@StatusType", DbType.String, StatusType)
                db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
                db.AddInParameter(dbComm, "@AutoID", DbType.String, AutoID)

                db.AddInParameter(dbComm, "@SO_ID", DbType.String, SO_ID)
                db.AddInParameter(dbComm, "@SP_ID", DbType.String, SP_ID)
                db.AddInParameter(dbComm, "@SS_Edition", DbType.String, SS_Edition)
                db.AddInParameter(dbComm, "@ClientBarcode", DbType.String, ClientBarcode)
                db.AddInParameter(dbComm, "@PM_M_Code", DbType.String, PM_M_Code)
                db.AddInParameter(dbComm, "@BarcodeType", DbType.String, BarcodeType)
                db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)

                db.AddInParameter(dbComm, "@StartDate", DbType.String, StartDate)
                db.AddInParameter(dbComm, "@EndDate", DbType.String, EndDate)
                db.AddInParameter(dbComm, "@AddUserID", DbType.String, AddUserID)
                db.AddInParameter(dbComm, "@BitAuto", DbType.Boolean, BitAuto)

                ds = db.ExecuteDataSet(dbComm)
                If ds.Tables.Count > 0 Then
                    Return ds.Tables(0)
                Else
                    Return Nothing
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Function

        Public Function NmetalSampleCollection_Getlist(ByVal StatusType As String, ByVal Code_ID As String, ByVal AutoID As String, ByVal SO_ID As String, ByVal SS_Edition As String, ByVal SP_ID As String, ByVal ReportEmpty As Boolean, ByVal ClientBarcode As String, ByVal PM_M_Code As String, ByVal BarcodeType As String, ByVal D_ID As String, ByVal StartDate As String, ByVal EndDate As String, ByVal AddUserID As String, ByVal BitAuto As String) As List(Of NmetalSampleCollectionInfo)

            Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
            Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_Getlist")

            db.AddInParameter(dbComm, "@StatusType", DbType.String, StatusType)
            db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
            db.AddInParameter(dbComm, "@AutoID", DbType.String, AutoID)

            db.AddInParameter(dbComm, "@SO_ID", DbType.String, SO_ID)
            db.AddInParameter(dbComm, "@SP_ID", DbType.String, SP_ID)
            db.AddInParameter(dbComm, "@SS_Edition", DbType.String, SS_Edition)
            db.AddInParameter(dbComm, "@ClientBarcode", DbType.String, ClientBarcode)
            db.AddInParameter(dbComm, "@PM_M_Code", DbType.String, PM_M_Code)
            db.AddInParameter(dbComm, "@BarcodeType", DbType.String, BarcodeType)
            db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)

            db.AddInParameter(dbComm, "@StartDate", DbType.String, StartDate)
            db.AddInParameter(dbComm, "@EndDate", DbType.String, EndDate)
            db.AddInParameter(dbComm, "@AddUserID", DbType.String, AddUserID)
            db.AddInParameter(dbComm, "@BitAuto", DbType.Boolean, BitAuto)


            Dim FeatureList As New List(Of NmetalSampleCollectionInfo)
            Using reader As IDataReader = db.ExecuteReader(dbComm)
                While reader.Read
                    FeatureList.Add(FillNmetalSampleCollectionType(reader))
                End While
                If FeatureList.Count <= 0 And ReportEmpty Then
                    FeatureList.Add(New NmetalSampleCollectionInfo())
                End If
                Return FeatureList
            End Using
        End Function

        ''' <summary>
        ''' 條碼採集查詢
        ''' 2014-04-21
        ''' 姚     駿
        ''' </summary>
        ''' <param name="D_ID"></param>
        ''' <param name="StatusType"></param>
        ''' <param name="SO_SampleID"></param>
        ''' <param name="PM_M_Code"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function NmetalSampleCollection_GetListByNewCondition(ByVal D_ID As String, ByVal StatusType As String, ByVal SO_SampleID As String, ByVal PM_M_Code As String) As List(Of NmetalSampleCollectionInfo)

            Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
            Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_GetListByNewCondition")

            db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
            db.AddInParameter(dbComm, "@StatusType", DbType.String, StatusType)
            db.AddInParameter(dbComm, "@SO_SampleID", DbType.String, SO_SampleID)
            db.AddInParameter(dbComm, "@PM_M_Code", DbType.String, PM_M_Code)

            Dim FeatureList As New List(Of NmetalSampleCollectionInfo)
            Using reader As IDataReader = db.ExecuteReader(dbComm)
                While reader.Read
                    FeatureList.Add(FillNmetalSampleCollectionType(reader))
                End While
                Return FeatureList
            End Using
        End Function


        ''' <summary>
        ''' 2014-04-18
        ''' 姚   駿
        ''' 存放循環報警-查詢部門超時的條碼明細
        ''' </summary>
        ''' <param name="D_ID"></param>
        ''' <param name="D_Second"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function NmetalSampleCollection_GetListByStore(ByVal D_ID As String, ByVal D_Second As String) As List(Of NmetalSampleCollectionInfo)

            Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
            Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_GetListByStore")

            db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
            db.AddInParameter(dbComm, "@D_Second", DbType.String, D_Second)

            Dim FeatureList As New List(Of NmetalSampleCollectionInfo)
            Using reader As IDataReader = db.ExecuteReader(dbComm)
                While reader.Read
                    FeatureList.Add(FillNmetalSampleCollectionType(reader))
                End While
                Return FeatureList
            End Using
        End Function


        Public Function NmetalSampleCollection_GetID(ByVal Code_ID As String) As Boolean
            Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
            Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_GetID")

            db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)

            Dim StrCode_ID As String = String.Empty
            Using reader As IDataReader = db.ExecuteReader(dbComm)
                While reader.Read
                    StrCode_ID = reader("Code_ID").ToString
                End While
                If StrCode_ID = String.Empty Then
                    Return False
                Else
                    Return True
                End If
            End Using
        End Function

        'Public Function NmetalSampleCollectionType_GetID(ByVal Code_ID As String) As String
        '    Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
        '    Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollectionType_GetID")

        '    db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)

        '    Dim StrCode_ID As String = String.Empty
        '    Using reader As IDataReader = db.ExecuteReader(dbComm)
        '        While reader.Read
        '            StrCode_ID = reader("StatusType").ToString
        '        End While
        '    End Using
        '    NmetalSampleCollectionType_GetID = StrCode_ID
        'End Function


        Public Function NmetalSampleCollection_UpdateA(ByVal Code_ID As String, ByVal StatusType As String) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_UpdateA")
                db.AddInParameter(dbComm, "@StatusType", DbType.String, StatusType)
                db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
                db.ExecuteNonQuery(dbComm)

                NmetalSampleCollection_UpdateA = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_UpdateA = False
            End Try
        End Function

        Public Function NmetalSampleCollection_UpdateB(ByVal Code_ID As String, ByVal SP_ID As String) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_UpdateB")
                db.AddInParameter(dbComm, "@SP_ID", DbType.String, SP_ID)
                db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
                db.ExecuteNonQuery(dbComm)

                NmetalSampleCollection_UpdateB = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_UpdateB = False
            End Try
        End Function

        Public Function NmetalSampleCollection_UpdateC(ByVal Code_ID As String, ByVal D_ID As String) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_UpdateC")
                db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
                db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
                db.ExecuteNonQuery(dbComm)

                NmetalSampleCollection_UpdateC = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_UpdateC = False
            End Try
        End Function

        Public Function NmetalSampleCollection_UpdateD(ByVal Code_ID As String, ByVal ClientBarcode As String) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_UpdateD")
                db.AddInParameter(dbComm, "@ClientBarcode", DbType.String, ClientBarcode)
                db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
                db.ExecuteNonQuery(dbComm)

                NmetalSampleCollection_UpdateD = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_UpdateD = False
            End Try
        End Function



        Friend Function FillNmetalSampleCollectionType(ByVal reader As IDataReader) As NmetalSampleCollectionInfo
            '对应取得的数据
            On Error Resume Next

            Dim objInfo As New NmetalSampleCollectionInfo

            objInfo.AddDate = CDate(reader("AddDate").ToString)
            objInfo.AddUserID = reader("AddUserID").ToString
            objInfo.AddUserName = reader("AddUserName").ToString
            objInfo.AutoID = reader("AutoID").ToString
            objInfo.Code_ID = reader("Code_ID").ToString

            objInfo.PM_M_Code = reader("PM_M_Code").ToString
            objInfo.ModifyDate = CDate(reader("ModifyDate").ToString)
            objInfo.ModifyUserID = reader("ModifyUserID").ToString
            objInfo.Qty = CInt(reader("Qty"))
            objInfo.Remark = reader("Remark").ToString
            objInfo.StatusType = reader("StatusType").ToString
            objInfo.StatusTypeName = reader("StatusTypeName").ToString

            objInfo.PM_Type = reader("PM_Type").ToString
            objInfo.SO_ID = reader("SO_ID").ToString
            objInfo.SP_ID = reader("SP_ID").ToString
            objInfo.SS_Edition = reader("SS_Edition").ToString
            objInfo.ClientBarcode = reader("ClientBarcode").ToString
            objInfo.BarcodeType = reader("BarcodeType").ToString
            objInfo.D_Dep = reader("D_Dep").ToString
            objInfo.D_ID = reader("D_ID").ToString
            objInfo.SO_SampleID = reader("SO_SampleID").ToString
            objInfo.ID = reader("ID").ToString
            objInfo.Type = reader("Type").ToString
            objInfo.BitAuto = reader("BitAuto")

            '2014-04-18 姚駿
            objInfo.CodeCount = reader("CodeCount")
            objInfo.SE_InTime = reader("SE_InTime")
            objInfo.IntSecond = reader("IntSecond")

            objInfo.IWeight = reader("IWeight")
            objInfo.RWeight = reader("RWeight")
            objInfo.TWeight = reader("TWeight")
            objInfo.SO_Type = reader("SO_Type")

            objInfo.PS_NO = reader("PS_NO")
            objInfo.PS_Name = reader("PS_Name")

            objInfo.TWeights = reader("TWeights")
            Return objInfo
        End Function

        ''' <summary>
        ''' 更新
        ''' 2014-08-20
        ''' Mark
        ''' </summary>
        ''' <param name="Code_ID">条码</param>
        ''' <param name="D_ID">部门</param>
        ''' <param name="StatusType">状态</param>
        ''' <param name="TWeight">重量</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function NmetalSampleCollection_UpdateH(ByVal Code_ID As String, ByVal D_ID As String, ByVal StatusType As String, ByVal TWeight As Decimal) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_UpdateH")
                db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
                db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
                db.AddInParameter(dbComm, "@StatusType", DbType.String, StatusType)
                db.AddInParameter(dbComm, "@TWeight", DbType.Decimal, TWeight)


                db.ExecuteNonQuery(dbComm)

                NmetalSampleCollection_UpdateH = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_UpdateH = False
            End Try
        End Function

#Region "條碼記錄"
        Public Function NmetalSamplePaceBarCodeAll_Getlist(ByVal Code_ID As String, ByVal AddDate1 As String, ByVal AddDate2 As String) As List(Of NmetalSampleCollectionInfo)

            Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
            Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSamplePaceBarCodeAll_Getlist")

            db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
            db.AddInParameter(dbComm, "@AddDate1", DbType.String, AddDate1)
            db.AddInParameter(dbComm, "@AddDate2", DbType.String, AddDate2)

            Dim FeatureList As New List(Of NmetalSampleCollectionInfo)
            Using reader As IDataReader = db.ExecuteReader(dbComm)
                While reader.Read
                    FeatureList.Add(FillNmetalSampleCollectionType(reader))
                End While
                Return FeatureList
            End Using
        End Function

        Public Function NmetalSampleCollectionLogin_Add(ByVal objinfo As NmetalSampleCollectionInfo) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollectionLogin_Add")

                db.AddInParameter(dbComm, "@Code_ID", DbType.String, objinfo.Code_ID)
                db.AddInParameter(dbComm, "@Qty", DbType.Int16, objinfo.Qty)
                db.AddInParameter(dbComm, "@StatusType", DbType.String, objinfo.StatusType)

                db.AddInParameter(dbComm, "@Barcode", DbType.String, objinfo.BarCode)
                db.AddInParameter(dbComm, "@D_ID", DbType.String, objinfo.D_ID)
                db.AddInParameter(dbComm, "@AddUserID", DbType.String, objinfo.AddUserID)

                db.ExecuteNonQuery(dbComm)
                NmetalSampleCollectionLogin_Add = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollectionLogin_Add = False
            End Try
        End Function

        Public Function NmetalSampleCollection_UpdateGIn(ByVal SE_ID As String, ByVal StatusType As String, ByVal D_ID As String, ByVal PS_NO As String, ByVal InputType As Boolean) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_UpdateGIn")

                db.AddInParameter(dbComm, "@SE_ID", DbType.String, SE_ID)
                db.AddInParameter(dbComm, "@StatusType", DbType.String, StatusType)
                db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
                db.AddInParameter(dbComm, "@PS_NO", DbType.String, PS_NO)
                db.AddInParameter(dbComm, "@InputType", DbType.Boolean, InputType)

                db.ExecuteNonQuery(dbComm)

                NmetalSampleCollection_UpdateGIn = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_UpdateGIn = False
            End Try
        End Function

        Public Function NmetalSampleCollection_UpdateGOut(ByVal SE_ID As String, ByVal StatusType As String, ByVal D_ID As String, ByVal PS_NO As String) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_UpdateGOut")

                db.AddInParameter(dbComm, "@SE_ID", DbType.String, SE_ID)
                db.AddInParameter(dbComm, "@StatusType", DbType.String, StatusType)
                db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
                db.AddInParameter(dbComm, "@PS_NO", DbType.String, PS_NO)

                db.ExecuteNonQuery(dbComm)

                NmetalSampleCollection_UpdateGOut = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_UpdateGOut = False
            End Try
        End Function

        Public Function NmetalSampleCollection_UpdateG(ByVal Code_ID As String, ByVal StatusType As String, ByVal D_ID As String, ByVal Tweight As Decimal, ByVal PS_NO As String) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_UpdateG")

                db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
                db.AddInParameter(dbComm, "@StatusType", DbType.String, StatusType)
                db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
                db.AddInParameter(dbComm, "@Tweight", DbType.Decimal, Tweight)
                db.AddInParameter(dbComm, "@PS_NO", DbType.String, PS_NO)

                db.ExecuteNonQuery(dbComm)

                NmetalSampleCollection_UpdateG = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_UpdateG = False
            End Try
        End Function


        ''' <summary>
        ''' 更新
        ''' 2014-06-26   Mark
        ''' </summary>
        ''' <param name="Code_ID"></param>
        ''' <param name="StatusType"></param>
        ''' <param name="ClientBarcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function NmetalSampleCollection_UpdateF(ByVal Code_ID As String, ByVal StatusType As String, ByVal ClientBarcode As String, ByVal TWeight As Decimal) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_UpdateF")
                db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
                db.AddInParameter(dbComm, "@StatusType", DbType.String, StatusType)
                db.AddInParameter(dbComm, "@ClientBarcode", DbType.String, ClientBarcode)
                db.AddInParameter(dbComm, "@TWeight", DbType.Decimal, TWeight)


                db.ExecuteNonQuery(dbComm)

                NmetalSampleCollection_UpdateF = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollection_UpdateF = False
            End Try
        End Function


        Public Function NmetalSampleCollectionSub_GetList(ByVal Code_ID As String, ByVal D_ID As String) As List(Of NmetalSampleCollectionInfo)

            Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
            Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollectionSub_GetList")

            db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
            db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
           
            Dim FeatureList As New List(Of NmetalSampleCollectionInfo)
            Using reader As IDataReader = db.ExecuteReader(dbComm)
                While reader.Read
                    FeatureList.Add(FillNmetalSampleCollectionType(reader))
                End While
                Return FeatureList
            End Using
        End Function

        Public Function NmetalSampleCollectionSub_Update(ByVal Code_ID As String, ByVal D_ID As String, ByVal Tweight As Decimal, ByVal Qty As Int16, ByVal ModifyUserID As String, ByVal ModifyDate As String) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollectionSub_Update")
                db.AddInParameter(dbComm, "@Code_ID", DbType.String, Code_ID)
                db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
                db.AddInParameter(dbComm, "@Tweight", DbType.Decimal, Tweight)

                db.AddInParameter(dbComm, "@Qty", DbType.Int16, Qty)
                db.AddInParameter(dbComm, "@ModifyUserID", DbType.String, ModifyUserID)
                db.AddInParameter(dbComm, "@ModifyDate", DbType.String, ModifyDate)

                db.ExecuteNonQuery(dbComm)
                NmetalSampleCollectionSub_Update = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleCollectionSub_Update = False
            End Try
        End Function
        ''' <summary>
        ''' Mark
        ''' 2014-07-30
        ''' </summary>
        ''' <param name="PS_NO"></param>
        ''' <param name="D_ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function NmetalSampleCollection_GetListProductWightOld(ByVal D_ID As String, ByVal PS_NO As String) As List(Of NmetalSampleCollectionInfo)

            Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
            Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleCollection_GetListProductWightOld")

            db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
            db.AddInParameter(dbComm, "@PS_NO", DbType.String, PS_NO)

            Dim FeatureList As New List(Of NmetalSampleCollectionInfo)
            Using reader As IDataReader = db.ExecuteReader(dbComm)
                While reader.Read
                    FeatureList.Add(FillNmetalSampleCollectionType(reader))
                End While
                Return FeatureList
            End Using
        End Function
#End Region
    End Class
End Namespace