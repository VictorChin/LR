Imports System.ComponentModel

Public Class CalculatorModel
    Implements INotifyPropertyChanged
    Implements ICalculatorModel

    Property Input1 As Nullable(Of Integer) Implements ICalculatorModel.Input1
    Property Input2 As Nullable(Of Integer) Implements ICalculatorModel.Input2
    Property result As Nullable(Of Integer) Implements ICalculatorModel.result
    Sub Sum() Implements ICalculatorModel.Calculate
        result = Input1 + Input2
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("result"))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

End Class
