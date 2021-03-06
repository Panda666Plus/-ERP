'Imports System.Data.SqlClient
'Imports System.Data.Common
'Imports System.Data.Sql
'Namespace LFERP.Library.NmetalSampleManager.NmetalSampleCollection
'    ''' <summary>
'    ''' 贵金属部门重量信息
'    ''' Mark
'    ''' 2014-06-27
'    ''' </summary>
'    ''' <remarks></remarks>
'    Public Class NmetalSampleDepWeightControler

'        ''' <summary>
'        ''' 查询表中数据
'        ''' Mark
'        ''' 2014-06-27
'        ''' </summary>
'        ''' <param name="D_ID"></param>
'        ''' <returns></returns>
'        ''' <remarks></remarks>
'        Public Function NmetalSampleDepWeight_GetList(ByVal D_ID As String, ByVal PM_M_Code As String) As List(Of NmetalSampleDepWeightInfo)

'            Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
'            Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleDepWeight_GetList")

'            db.AddInParameter(dbComm, "@D_ID", DbType.String, D_ID)
'            db.AddInParameter(dbComm, "@PM_M_Code", DbType.String, PM_M_Code)

'            Dim FeatureList As New List(Of NmetalSampleDepWeightInfo)
'            Using reader As IDataReader = db.ExecuteReader(dbComm)
'                While reader.Read
'                    FeatureList.Add(FillNmetalSampleDepWeight(reader))
'                End While
'                Return FeatureList
'            End Using
'        End Function

'        ''' <summary>
'        ''' 更增表中数据
'        ''' Mark
'        ''' 2014-06-27
'        ''' </summary>
'        ''' <param name="objinfo"></param>
'        ''' <returns></returns>
'        ''' <remarks></remarks>
'        Public Function NmetalSampleDepWeight_Update(ByVal objinfo As NmetalSampleDepWeightInfo) As Boolean
'            Try
'                Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)
'                Dim dbComm As DbCommand = db.GetStoredProcCommand("NmetalSampleDepWeight_Update")

'                db.AddInParameter(dbComm, "@SO_ID", DbType.String, objinfo.SO_ID)
'                db.AddInParameter(dbComm, "@SS_Edition", DbType.String, objinfo.SS_Edition)
'                db.AddInParameter(dbComm, "@PM_M_Code", DbType.String, objinfo.PM_M_Code)
'                db.AddInParameter(dbComm, "@PM_Type", DbType.String, objinfo.PM_Type)
'                db.AddInParameter(dbComm, "@D_ID", DbType.String, objinfo.D_ID)

'                db.AddInParameter(dbComm, "@DepWight", DbType.Decimal, objinfo.DepWight)
'                db.AddInParameter(dbComm, "@ModifyUserID", DbType.String, objinfo.ModifyUserID)
'                db.AddInParameter(dbComm, "@ModifyDate", DbType.DateTime, objinfo.ModifyDate)


'                db.ExecuteNonQuery(dbComm)
'                NmetalSampleDepWeight_Update = True
'            Catch ex As Exception
'                MsgBox(ex.Message)
'                NmetalSampleDepWeight_Update = False
'            End Try
'        End Function

'        ''' <summary>
'        ''' 绑定对应的数据
'        ''' Mark
'        ''' 2014-06-27
'        ''' </summary>
'        ''' <param name="reader"></param>
'        ''' <returns></returns>
'        ''' <remarks></remarks>
'        Friend Function FillNmetalSampleDepWeight(ByVal reader As IDataReader) As NmetalSampleDepWeightInfo
'            On Error Resume Next
'            Dim objInfo As New NmetalSampleDepWeightInfo
'            objInfo.AutoID = reader("AutoID").ToString
'            objInfo.SO_ID = reader("SO_ID").ToString
'            objInfo.SS_Edition = reader("SS_Edition").ToString
'            objInfo.PM_M_Code = reader("PM_M_Code").ToString
'            objInfo.PM_Type = reader("PM_Type").ToString

'            objInfo.D_ID = reader("D_ID").ToString
'            objInfo.DepWight = reader("DepWight").ToString
'            objInfo.AddUserID = reader("AddUserID").ToString
'            objInfo.AddDate = CDate(reader("AddDate").ToString)
'            objInfo.ModifyUserID = reader("ModifyUserID").ToString

'            objInfo.ModifyDate = CDate(reader("ModifyDate").ToString)
'            objInfo.SE_TypeName = reader("SE_TypeName").ToString
'            objInfo.DepName = reader("DepName").ToString
'            Return objInfo
'        End Function
'    End Class
'End Namespace

Public Class NmetalSampleDepWeightControler

End Class

