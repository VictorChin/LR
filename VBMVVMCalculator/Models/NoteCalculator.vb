Public Class NoteCalculator
    Implements ICalculatorModel
    Private _getter As INoteProductionGetter
    Sub New(getter As INoteProductionGetter)
        _getter = getter
    End Sub
    Public Sub Calculate() Implements ICalculatorModel.Calculate
        If (Input1 Is Nothing) OrElse (Input2 Is Nothing) Then
            Throw New ArgumentException("call bradley")
        End If
        Dim billCount = _getter.GetNoteProductionCount(Input1, Input2)
        If (billCount Is Nothing) Then
            result = 0
        Else
            result = billCount
        End If
    End Sub

    Public Property Input1 As Integer? Implements ICalculatorModel.Input1

    Public Property Input2 As Integer? Implements ICalculatorModel.Input2

    Public Property result As Integer? Implements ICalculatorModel.result
End Class
