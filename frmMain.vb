Imports System.Drawing.Printing
Imports System.Data.SqlClient

Imports LinxLib.DataLib
Imports LinxLib.CommonLib
Imports LinxLib.Settings
Imports LinxLib.XMLLib
Imports LinxLib.LinxmasterLib
Imports LinxLib
Imports System.Windows.Forms

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Public MySettings As New Settings()

    Public bDebugMode As Boolean = False

    Public sExeVersion As String = "1.0"

    Private DaqBoard As MccDaq.MccBoard = New MccDaq.MccBoard(0)

    Private bMDAQConnected As Boolean = False


    ' Digital out
    Private PortType As Integer
    Private PortNum As MccDaq.DigitalPortType
    Private NumPorts, NumBits, MaxPortVal As Integer
    Private ProgAbility As Integer

    ' Analogue in
    Private Range As MccDaq.Range
    Private ADResolution, NumAIChans, HighChan As Integer

    Private Direction As MccDaq.DigitalPortDirection

    Private iSampleCount As Integer
    Private iPhase As Integer


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        lblExeVersion.Text = "Exe:" & sExeVersion
        lblLinxLibVersion.Text = "Lib:" & sLinxLibVersion

        If GetConfigData("debug") = "TEST" Then bDebugMode = True

        Dim PortName As String
        Dim FirstBit As Integer
        Dim ULStat As MccDaq.ErrorInfo

        InitUL()    'initiate error handling, etc

        'determine if digital port exists, its capabilities, etc
        PortType = PORTOUT
        NumPorts = FindPortsOfType(DaqBoard, PortType, ProgAbility, PortNum, NumBits, FirstBit)


        ' Digital out
        If NumPorts < 1 Then

            bMDAQConnected = False
            btnStart.Enabled = False

        Else

            bMDAQConnected = True
            ' if programmable, set direction of port to output
            ' configure the first port for digital output
            '  Parameters:
            '    PortNum        :the output port
            '    Direction      :sets the port for input or output
            If ProgAbility = DigitalIO.PROGPORT Then
                Direction = MccDaq.DigitalPortDirection.DigitalOut
                ULStat = DaqBoard.DConfigPort(PortNum, Direction)
                If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            End If
            PortName = PortNum.ToString
            ' MsgBox("Set the output value of " & PortName & " on board " & DaqBoard.BoardNum.ToString() &
            ' " using the scroll bar or enter a value in the 'Value set' box.")
        End If


        If bMDAQConnected Then
            ' Analogue in
            Dim LowChan As Integer
            Dim ChannelType As Integer
            Dim DefaultTrig As MccDaq.TriggerType

            ChannelType = ANALOGINPUT
            NumAIChans = FindAnalogChansOfType(DaqBoard, ChannelType,
                ADResolution, Range, LowChan, DefaultTrig)

            If (NumAIChans = 0) Then
                MsgBox("Board " & DaqBoard.BoardNum.ToString() & " does not have analog input channels")
                btnStart.Enabled = False

            Else
                Dim CurFunc As String
                CurFunc = "MccBoard.AIn"
                If (ADResolution > 16) Then CurFunc = "MccBoard.AIn32"
                HighChan = LowChan + NumAIChans - 1
            End If

        End If


        btnStart.Enabled = True

        txtStatus.Text = ""
        txtSerial_Number.Text = ""
        txtReading1.Text = ""
        txtReading2.Text = ""
        txtDifference.Text = ""
        txtSerial_Number_Display.Text = ""

        ' Check serial number exists 
        If PrintHeadExists("") Is Nothing Then
            MsgBox("Unable to attach to database")
        End If

        If bMDAQConnected Then
            DisplayResult("Idle")
        Else
            txtStatus.Text = "MDAQ fail"
            DisplayResult("No start")
        End If

        Me.Show()
        LED_Display(0)
        txtSerial_Number.Focus()

    End Sub

    Private Sub btnExit_Click_1(sender As Object, e As EventArgs) Handles btnExit.Click

        If bMDAQConnected Then Send_Digital(0)
        End

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        txtStatus.Text = ""
        txtReading1.Text = ""
        txtReading2.Text = ""
        txtDifference.Text = ""
        txtSerial_Number_Display.Text = ""
        lblResult.Text = ""
        txtSerial_Number.Focus()
        StartProcess()

    End Sub


    Public Sub StartProcess()

        Dim xBindingsource As BindingSource = Nothing

        Dim sResult As String

        Dim iDelay As Integer = 0
        Dim lVolt1, lVolt2, lDiff, lVoltHigh, lVoltLow As Double

        lVoltHigh = Double.Parse(GetConfigData("voltage_high"))
        lVoltLow = Double.Parse(GetConfigData("voltage_low"))

        If ValidatePHSerial(txtSerial_Number.Text) Then

            txtSerial_Number_Display.Text = ""

            ' Check serial number exists 
            If PrintHeadExists(txtSerial_Number.Text).Count = 0 Then
                txtSerial_Number_Display.Text = "Not found!"
                WaitHere(30)
                txtStatus.Text = ""
                txtSerial_Number.Text = ""
                txtSerial_Number_Display.Text = ""
                Exit Sub
            End If

            txtSerial_Number_Display.Text = txtSerial_Number.Text
            txtSerial_Number.Text = ""

            txtStatus.Text = "Pump on"
            DisplayResult("Start")
            Send_Digital(42)
            ' Wait pump time
            iDelay = Integer.Parse(GetConfigData("pump_runseconds"))
            WaitHere(iDelay * 10)

            txtStatus.Text = "Close valve"
            DisplayResult("Close V1")
            ' Close valve                
            Send_Digital(34)

            ' Wait 1 second
            txtStatus.Text = "Stop pump"
            DisplayResult("Reading")
            WaitHere(10)

            ' Stop pump
            Send_Digital(2)

            ' Wait 1 second
            WaitHere(10)
            txtStatus.Text = "Reading"
            DisplayResult("Read 1")

            iPhase = 0
            StartConvert(10)

            lVolt1 = CDbl(txtReading1.Text.Replace("Volts", ""))

            ' Outside limits
            If lVolt1 < lVoltLow Or lVolt1 > lVoltHigh Then
                Send_Digital(20)
                DisplayResult("Fail")
                txtStatus.Text = "Check vacuum"
                WaitHere(30)
                Send_Digital(0)
                Exit Sub
            End If

            iDelay = Integer.Parse(GetConfigData("vacuum_seconds"))
            txtStatus.Text = "Wait " & CStr(iDelay) & " secs"
            DisplayResult("Read 2")
            WaitHere(iDelay * 10)

            iPhase = 1
            StartConvert(10)

            lVolt1 = CDbl(txtReading1.Text.Replace("Volts", ""))
            lVolt2 = CDbl(txtReading2.Text.Replace("Volts", ""))

            lDiff = Math.Abs(lVolt1 - lVolt2)

            txtDifference.Text = FormatNumber(lDiff, 4, TriState.True)

            If lDiff > Double.Parse(GetConfigData("voltage_diff")) Then
                txtStatus.Text = "Vacuum leak"
                DisplayResult("Fail")
                sResult = "NO"
                Send_Digital(20)
                WaitHere(30)
            Else
                txtStatus.Text = "Finish"
                DisplayResult("Pass")
                sResult = "YES"
                Send_Digital(17)

            End If

            WaitHere(30)
            Send_Digital(1)

            ' Send data to table
            UpdatePrinterHead(txtSerial_Number_Display.Text, sResult)

        Else
            txtSerial_Number_Display.Text = ""
            txtStatus.Text = "Serial number not found!"

            WaitHere(30)

            txtReading1.Text = ""
            txtReading2.Text = ""
            txtDifference.Text = ""
            txtSerial_Number.Text = ""
            txtStatus.Text = ""

        End If

        WaitHere(200)

        txtReading1.Text = ""
        txtReading2.Text = ""
        txtDifference.Text = ""
        txtSerial_Number_Display.Text = ""
        txtSerial_Number.Text = ""

        Send_Digital(0)

        txtSerial_Number.Focus()

        DisplayResult("Idle")

    End Sub


    Public Function PrintHeadExists(ByRef sSerial As String) As BindingSource

        PrintHeadExists = Nothing

        Dim tDatafetch(0) As DataIn
        Dim xDataAccess As New DataAccess

        Try
            xDataAccess.Initialise()
            xDataAccess.SetScheme = "dbo"
            xDataAccess.SetTableName = "PrintheadRecentStarts"
            If xDataAccess.GetConnectionErr <> "" Then
                MsgBox(xDataAccess.GetConnectionErr)
                Exit Function
            End If
            xDataAccess.SetDBWhere = "serial='" & Trim(sSerial) & "'"

            ReDim tDatafetch(12)
            tDatafetch(0).ColName = "product"
            tDatafetch(1).ColName = "start_time"
            tDatafetch(2).ColName = "use_time"
            tDatafetch(3).ColName = "pack_time"
            tDatafetch(4).ColName = "scrapped"
            tDatafetch(5).ColName = "order_time"
            tDatafetch(6).ColName = "step1"
            tDatafetch(7).ColName = "step2"
            tDatafetch(8).ColName = "step3"
            tDatafetch(9).ColName = "potting_success"
            tDatafetch(10).ColName = "step4"
            tDatafetch(11).ColName = "vacuum_scan"
            tDatafetch(12).ColName = "vacuum_success"

            Dim oBindingSource As BindingSource
            oBindingSource = xDataAccess.GetRecordsDataByID(tDatafetch)
            PrintHeadExists = oBindingSource

        Catch ex As Exception

            MsgBox("PrintHeadExists: Not found " & sSerial)

        End Try

    End Function


    Private Sub InitUL()

        Dim ULStat As MccDaq.ErrorInfo

        ULStat = MccDaq.MccService.DeclareRevision(MccDaq.MccService.CurrentRevNum)

        ReportError = MccDaq.ErrorReporting.PrintAll
        HandleError = MccDaq.ErrorHandling.StopAll
        ULStat = MccDaq.MccService.ErrHandling(ReportError, HandleError)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
            Stop
        End If

    End Sub


    Public Sub Send_Digital(ByVal output As Integer)

        Dim ULStat As MccDaq.ErrorInfo
        Dim DataValue As UInt16

        DataValue = Convert.ToUInt16(output)
        ULStat = DaqBoard.DOut(PortNum, DataValue)

        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
            Stop
        End If


        LED_Display(output)


    End Sub

    Private Sub LED_Display(ByVal counter As Integer)

        Dim bStr As String = CStr(ToBinary(counter))
        bStr = bStr.ToString().PadLeft(6, "0")


        If Mid(bStr, 1, 1) = "0" Then
            txtPump.BackColor = Color.Silver
        Else
            txtPump.BackColor = Color.Tomato
        End If

        If Mid(bStr, 2, 1) = "0" Then
            txtV2.BackColor = Color.Silver
        Else
            txtV2.BackColor = Color.Yellow
        End If

        If Mid(bStr, 3, 1) = "0" Then
            txtV1.BackColor = Color.Silver
        Else
            txtV1.BackColor = Color.Yellow
        End If

        If Mid(bStr, 4, 1) = "0" Then
            txtRed.BackColor = Color.Silver
        Else
            txtRed.BackColor = Color.Red
        End If

        If Mid(bStr, 5, 1) = "0" Then
            txtOrange.BackColor = Color.Silver
        Else
            txtOrange.BackColor = Color.Orange
        End If

        If Mid(bStr, 6, 1) = "0" Then
            txtGreen.BackColor = Color.Silver
        Else
            txtGreen.BackColor = Color.Lime
        End If




    End Sub



    Private Function ToBinary(dec As Integer) As String
        Dim bin As Integer
        Dim output As String = ""
        While dec <> 0
            If dec Mod 2 = 0 Then
                bin = 0
            Else
                bin = 1
            End If
            dec = dec \ 2
            output = Convert.ToString(bin) & output
        End While
        If output Is Nothing Then
            Return "0"
        Else
            Return output
        End If
    End Function


    Private Sub WaitHere(ByRef iTenthSeconds As Integer)

        Timer1.Interval = iTenthSeconds * 100
        Timer1.Enabled = True

        Do While Timer1.Enabled
            Application.DoEvents()
        Loop



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False

    End Sub

    Private Sub txtV1_TextChanged(sender As Object, e As EventArgs) Handles txtV1.TextChanged

    End Sub

    Private Sub StartConvert(ByVal iTest As Integer)

        iSampleCount = iTest

        If tmrConvert.Enabled Then
            tmrConvert.Enabled = False
        Else
            tmrConvert.Enabled = True
        End If

        Application.DoEvents()

        Do While tmrConvert.Enabled
            Application.DoEvents()
        Loop

    End Sub


    Private Sub tmrConvert_Tick(ByVal eventSender As System.Object,
                ByVal eventArgs As System.EventArgs) Handles tmrConvert.Tick

        Dim EngUnits As Single
        Dim HighResEngUnits As Double
        Dim ULStat As MccDaq.ErrorInfo
        Dim DataValue As System.UInt16
        Dim DataValue32 As System.UInt32
        Dim Chan As Integer
        Dim ValidChan As Boolean

        Dim Options As Integer = 0

        iSampleCount -= 1

        '' txtStatus.Text = iSampleCount

        If iSampleCount = 0 Then
            ''txtStatus.Text = iSampleCount
            tmrConvert.Enabled = False

            Exit Sub
        End If

        ' Collect the data by calling AIn member function of MccBoard object
        '  Parameters:
        '    Chan       :the input channel number
        '    Range      :the Range for the board.
        '    DataValue  :the name for the value collected

        ' set input channel
        ValidChan = Integer.TryParse(GetConfigData("analogue_channel"), Chan)

        If ValidChan Then
            If (Chan > HighChan) Then Chan = HighChan
        End If

        If ADResolution > 16 Then
            ULStat = DaqBoard.AIn32(Chan, Range, DataValue32, Options)
            If Not ULStat.Value = MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            ' Convert raw data to Volts by calling ToEngUnits (member function of MccBoard class)  
            ULStat = DaqBoard.ToEngUnits32(Range, DataValue32, HighResEngUnits)
            ''txtReading1.Text = DataValue32.ToString()                ' print the counts
            If iPhase = 0 Then
                txtReading1.Text = HighResEngUnits.ToString("F5") & " Volts" ' print the voltage
            Else
                txtReading2.Text = HighResEngUnits.ToString("F5") & " Volts" ' print the voltage
            End If

        Else
            ULStat = DaqBoard.AIn(Chan, Range, DataValue)
            If Not ULStat.Value = MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            ' Convert raw data to Volts by calling ToEngUnits (member function of MccBoard class)  
            ULStat = DaqBoard.ToEngUnits(Range, DataValue, EngUnits)
            ''lblShowData.Text = DataValue.ToString()                ' print the counts
            If iPhase = 0 Then
                txtReading1.Text = EngUnits.ToString("F4") & " Volts" ' print the voltage
            Else
                txtReading2.Text = EngUnits.ToString("F4") & " Volts" ' print the voltage
            End If

        End If

        tmrConvert.Start()

    End Sub

    Private Sub DisplayResult(ByVal sResult As String)

        If sResult = "Fail" Then
            lblResult.ForeColor = Color.Red
        ElseIf sResult = "Pass" Then
            lblResult.ForeColor = Color.DarkGreen
        Else
            lblResult.ForeColor = Color.Black
        End If

        lblResult.Text = sResult
        Application.DoEvents()

    End Sub


    Public Sub UpdatePrinterHead(ByRef sSerial As String, ByVal sResult As String)

        Dim tDataIn(0) As DataIn
        Dim bResult As Boolean
        bResult = False

        Dim xDataAccess As New DataAccess
        xDataAccess.Initialise()
        xDataAccess.SetScheme = "dbo"
        xDataAccess.SetTableName = "PrintheadRecentStarts"
        If xDataAccess.GetConnectionErr <> "" Then
            MsgBox(xDataAccess.GetConnectionErr)
            Exit Sub
        End If

        xDataAccess.SetDBWhere = "serial='" & sSerial & "'"

        ReDim Preserve tDataIn(1)
        tDataIn(0) = xDataAccess.SQLVar("vacuum_success", sResult)
        tDataIn(1) = xDataAccess.SQLVar("vacuum_scan", Format(Now, "yyyy-MM-dd hh:mm:ss"))

        Try
            bResult = xDataAccess.UpdateNewRecordArray(tDataIn)

        Catch


        End Try



    End Sub

    Private Sub txtSerial_Number_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerial_Number.KeyDown

        If Len(txtSerial_Number.Text) = 8 Then
            StartProcess()
        End If


    End Sub
End Class
