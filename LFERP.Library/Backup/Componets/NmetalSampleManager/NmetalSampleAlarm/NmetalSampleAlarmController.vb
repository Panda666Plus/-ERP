Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.Sql
Namespace LFERP.Library.NmetalSampleManager.NmetalSampleAlarm
    Public Class NmetalSampleAlarmController
        Friend Function FillNmetalSampleAlarm(ByVal reader As IDataReader) As NmetalSampleAlarmInfo
            On Error Resume Next
            Dim objInfo As New NmetalSampleAlarmInfo
            objInfo.SE_ID = reader("SE_ID").ToString
            objInfo.SE_OutD_ID = reader("SE_OutD_ID").ToString
            objInfo.SE_InD_ID = reader("SE_InD_ID").ToString
            objInfo.SE_AddUserID = reader("SE_AddUserID").ToString
            objInfo.SE_OutD_Dep = reader("SE_OutD_Dep").ToString
            objInfo.SE_InD_Dep = reader("SE_InD_Dep").ToString
            objInfo.SE_Qty = reader("SE_Qty")
            objInfo.SE_AddUserName = reader("SE_AddUserName").ToString
            objInfo.SE_AddDate = reader("SE_AddDate")
            objInfo.SE_OutCardID = reader("SE_OutCardID").ToString
            objInfo.SE_InCardID = reader("SE_InCardID").ToString
            objInfo.ProcessResult = reader("ProcessResult").ToString
            objInfo.AddUserID = reader("AddUserID").ToString
            objInfo.CheckBit = reader("CheckBit")
            objInfo.CheckAction = reader("CheckAction").ToString
            objInfo.CheckDate = reader("CheckDate")
            objInfo.CheckRemark = reader("CheckRemark").ToString
            objInfo.AddUserName = reader("AddUserName").ToString
            objInfo.CheckActionName = reader("CheckActionName").ToString
            objInfo.SO_SampleID = reader("SO_SampleID").ToString
            objInfo.PM_M_Code = reader("PM_M_Code").ToString
            objInfo.D_ID = reader("D_ID").ToString
            objInfo.OccurReason = reader("OccurReason").ToString
            objInfo.D_Dep = reader("D_Dep").ToString
            objInfo.OccurAddress = reader("OccurAddress").ToString
            objInfo.Remark = reader("Remark").ToString
            objInfo.PutInQty = reader("PutInQty")
            objInfo.PutInCount = reader("PutInCount")
            objInfo.RatioQty = reader("RatioQty")
            objInfo.RatioCount = reader("RatioCount")
            objInfo.EmailTilte = reader("EmailTilte").ToString
            objInfo.SE_DelUserID = reader("SE_DelUserID").ToString
            objInfo.SE_InTime = reader("SE_InTime").ToString
            objInfo.DutyUserID = reader("DutyUserID").ToString
            objInfo.SE_TypeName = reader("SE_TypeName").ToString
            Return objInfo
        End Function

        Public Function NmetalSampleAlarm_GetList(ByVal SE_ID As String) As List(Of NmetalSampleAlarmInfo)
            Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
            Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleAlarm_GetList")

            db.AddInParameter(dbComm, "@SE_ID", DbType.String, SE_ID)

            Dim FeatureList As New List(Of NmetalSampleAlarmInfo)
            Using reader As IDataReader = db.ExecuteReader(dbComm)
                While reader.Read
                    FeatureList.Add(FillNmetalSampleAlarm(reader))
                End While
                Return FeatureList
            End Using
        End Function

        Public Function NmetalSampleAlarm_Delete(ByVal AutoID As String, ByVal SE_ID As String) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleAlarm_Delete")

                db.AddInParameter(dbComm, "@AutoID", DbType.String, AutoID)
                db.AddInParameter(dbComm, "@SE_ID", DbType.String, SE_ID)

                db.ExecuteNonQuery(dbComm)
                NmetalSampleAlarm_Delete = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleAlarm_Delete = False
            End Try
        End Function

        Public Function NmetalSampleAlarm_Update(ByVal objinfo As NmetalSampleAlarmInfo) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleAlarm_Update")

                db.AddInParameter(dbComm, "@SE_ID", DbType.String, objinfo.SE_ID)
                db.AddInParameter(dbComm, "@ProcessResult", DbType.String, objinfo.ProcessResult)
                db.AddInParameter(dbComm, "@ModifyUserID", DbType.String, objinfo.ModifyUserID)
                db.AddInParameter(dbComm, "@ModifyDate", DbType.Date, objinfo.ModifyDate)
                db.AddInParameter(dbComm, "@D_ID", DbType.String, objinfo.D_ID)
                db.AddInParameter(dbComm, "@DutyUserID", DbType.String, objinfo.DutyUserID)
                db.AddInParameter(dbComm, "@OccurReason", DbType.String, objinfo.OccurReason)
                db.AddInParameter(dbComm, "@OccurAddress", DbType.String, objinfo.OccurAddress)
                db.AddInParameter(dbComm, "@Remark", DbType.String, objinfo.Remark)

                db.ExecuteNonQuery(dbComm)
                NmetalSampleAlarm_Update = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleAlarm_Update = False
            End Try
        End Function

        Public Function NmetalSampleAlarm_Add(ByVal objinfo As NmetalSampleAlarmInfo) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleAlarm_Add")

                db.AddInParameter(dbComm, "@SE_ID", DbType.String, objinfo.SE_ID)
                db.AddInParameter(dbComm, "@ProcessResult", DbType.String, objinfo.ProcessResult)
                db.AddInParameter(dbComm, "@AddUserID", DbType.String, objinfo.AddUserID)
                db.AddInParameter(dbComm, "@AddDate", DbType.Date, objinfo.AddDate)
                db.AddInParameter(dbComm, "@D_ID", DbType.String, objinfo.D_ID)
                db.AddInParameter(dbComm, "@DutyUserID", DbType.String, objinfo.DutyUserID)

                db.AddInParameter(dbComm, "@OccurReason", DbType.String, objinfo.OccurReason)
                db.AddInParameter(dbComm, "@OccurAddress", DbType.String, objinfo.OccurAddress)
                db.AddInParameter(dbComm, "@Remark", DbType.String, objinfo.Remark)
                db.ExecuteNonQuery(dbComm)
                NmetalSampleAlarm_Add = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleAlarm_Add = False
            End Try
        End Function

        Public Function NmetalSampleAlarm_Check(ByVal objinfo As NmetalSampleAlarmInfo) As Boolean
            Try
                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleAlarm_Check")

                db.AddInParameter(dbComm, "@SE_ID", DbType.String, objinfo.SE_ID)
                db.AddInParameter(dbComm, "@CheckAction", DbType.String, objinfo.CheckAction)
                db.AddInParameter(dbComm, "@CheckDate", DbType.Date, objinfo.CheckDate)
                db.AddInParameter(dbComm, "@CheckBit", DbType.Boolean, objinfo.CheckBit)
                db.AddInParameter(dbComm, "@CheckRemark", DbType.String, objinfo.CheckRemark)

                db.ExecuteNonQuery(dbComm)
                NmetalSampleAlarm_Check = True
            Catch ex As Exception
                MsgBox(ex.Message)
                NmetalSampleAlarm_Check = False
            End Try
        End Function
    End Class

End Namespace