Public Class frmMain

    Private cnnDB As New ADODB.Connection
    Private RS As New ADODB.Recordset
    Private strSQL = "SELECT * FROM [DublinBikes_SourceData] ORDER BY [DB_ID] ASC;"
    Private strCSVLive = "C:\Users\winds\Documents\UCD Semester 02\COMP30670 - Software Engineering\Dublin Bikes\DublinBikes\CSV Files\"
    Private strCSVArchive = "C:\Users\winds\Documents\UCD Semester 02\COMP30670 - Software Engineering\Dublin Bikes\DublinBikes\CSV Files\Archive\"

    Private Sub DoPoll()
        Dim strFileFrom As String
        Dim strFileTo As String
        Dim strFileTimeStamp As String
        Dim iCtr As Integer
        Dim iTemp As Integer
        Dim strTemp As String

        strFileFrom = Dir(strCSVLive)
        If strFileFrom = "" Then
            Exit Sub
        Else
            strFileTimeStamp = strFileFrom.Substring(0, (strFileFrom.Length - 4))
            strFileTo = strCSVArchive & strFileFrom
            strFileFrom = strCSVLive & strFileFrom
            ' CONNECT TO THE DATABASE
            RS.CursorLocation = ADODB.CursorLocationEnum.adUseServer
            RS.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
            RS.LockType = ADODB.LockTypeEnum.adLockOptimistic
            RS.Open(strSQL, cnnDB,)
            AddToList("Data Recordset Open...")
            AddToList(Format(RS.RecordCount, "#,##0") & " Records currently in the recordset...")
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(strFileFrom)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")
                Dim currentRow As String()
                currentRow = MyReader.ReadFields()
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        Dim currentField As String
                        ' ADD THE DATA FROM THE CSV
                        RS.AddNew()
                        RS.Fields("DB_File").Value = strFileTimeStamp
                        iCtr = 2
                        For Each currentField In currentRow
                            RS.Fields(iCtr).Value = currentField
                            If iCtr = 13 Then
                                strTemp = currentField
                                strTemp = Replace(strTemp, "'lat':", "")
                                strTemp = Replace(strTemp, "'lng':", "")
                                strTemp = Replace(strTemp, "}", "")
                                strTemp = Replace(strTemp, "{", "")
                                strTemp = Trim(strTemp)
                                iTemp = InStr(strTemp, ",")
                                iCtr += 1
                                RS.Fields(iCtr).Value = Trim(strTemp.Substring(0, (iTemp - 1)))
                                iCtr += 1
                                RS.Fields(iCtr).Value = Trim(strTemp.Substring((iTemp + 1)))
                            End If
                            iCtr += 1
                        Next
                        RS.Update()
                        AddToList("Record Added...")
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                    End Try
                End While
            End Using
            RS.Close()
            AddToList("Data Recordset Closed...")
            System.IO.File.Move(strFileFrom, strFileTo)
            AddToList("CSV File Moved To Archive...")
        End If

    End Sub

    Private Sub AddToList(strDown As String)
        lstLog.Items.Add(strDown)
        lstLog.SelectedIndex = (lstLog.Items.Count - 1)

    End Sub

    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        Dim strSQL As String
        AddToList("Establishing Connection to Database...")
        Try
            cnnDB.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\winds\Documents\UCD Semester 02\COMP30670 - Software Engineering\Dublin Bikes\Dublin Bikes.accdb;Persist Security Info=False;")
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly, "Error...")
        End Try
        AddToList("Database Connection Established...")
        tmrPoll.Interval = (CInt(cboMins.Text) * 60000)
        tmrPoll.Enabled = True
    End Sub

    Private Sub cmdTerminate_Click(sender As Object, e As EventArgs) Handles cmdTerminate.Click
        tmrPoll.Enabled = False
        AddToList("Terminating Connection to Database...")
        Try
            cnnDB.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly, "Error...")
        End Try
        AddToList("Database Connection Terminated...")
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboMins.SelectedIndex = 4
        AddToList("DQ Listener Initialised...")
    End Sub

    Private Sub tmrPoll_Tick(sender As Object, e As EventArgs) Handles tmrPoll.Tick
        Try
            Call DoPoll()
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly, "Error...")
        End Try
    End Sub
End Class
