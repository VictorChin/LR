Imports System.IO
Imports Newtonsoft.Json

Public Class NoteProductionGetter
    Implements INoteProductionGetter


    Public Function GetNoteProductionCount(year As Integer, denomination As Integer) As Integer? Implements INoteProductionGetter.GetNoteProductionCount

        Dim respsone = Net.WebRequest.Create("https://explore.data.gov/resource/annual-production-figures-of-united-states-currency.json").GetResponse()
        Dim sr = New StreamReader(respsone.GetResponseStream())
        Dim col = JsonConvert.DeserializeObject(Of RootObject())(sr.ReadToEnd())

        Dim denom = CType(denomination, BillName)

        Dim q = From p In col
                Where p.fiscal_year = "FY " & year.ToString()
                Select New With {.BillCount = p.GetBillCount(denom)}

        Return q.First.BillCount
    End Function
End Class
Public Enum BillName
    One = 1
    Two = 2
    Five = 5
    Ten = 10
    Twenty = 20
    Fifty = 50
    Hundred = 100
End Enum
Public Class RootObject
    Public Function GetBillCount(bill As BillName) As Integer?
        Select Case bill
            Case BillName.One
                Return Me._1_bills
            Case BillName.Two
                Return Me._2_bills
            Case BillName.Five
                Return Me._5_bills
            Case BillName.Ten
                Return Me._10_bills
            Case BillName.Twenty
                Return Me._20_bills
            Case BillName.Fifty
                Return Me._50_bills
            Case BillName.Hundred
                Return Me._100_bills
            Case Else
                Return Nothing
        End Select

    End Function
    Public fiscal_year As String
    Public _20_bills As String
    Public _2_bills As String
    Public _100_bills As String
    Public _10_bills As String
    Public _5_bills As String
    Public _50_bills As String
    Public _1_bills As String
End Class
Public Interface INoteProductionGetter
    Function GetNoteProductionCount(year As Integer, denomination As Integer) As Integer?

End Interface
