Public Class NoteCalculator
    Implements ICalculatorModel
    Private _getter As INoteProductionGetter
    Sub New(getter As INoteProductionGetter)
        _getter = getter
    End Sub
    Public Sub Calculate() Implements ICalculatorModel.Calculate
        result = _getter.GetNoteProductionCount(Input1, Input2)

    End Sub

    Public Property Input1 As Integer? Implements ICalculatorModel.Input1

    Public Property Input2 As Integer? Implements ICalculatorModel.Input2

    Public Property result As Integer? Implements ICalculatorModel.result
End Class
