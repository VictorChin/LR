Public Class CalculatorViewModel


    Private _model As CalculatorModel
    Property input1Content As String
        Get
            Return _model.Input1.ToString()
        End Get
        Set(value As String)
            _model.Input1 = CType(value, Integer)
        End Set
    End Property
    Property input2Content As String
        Get
            Return _model.Input2.ToString()
        End Get
        Set(value As String)
            _model.Input2 = CType(value, Integer)
        End Set
    End Property
    ReadOnly Property resultContent As String
        Get
            Return _model.result.ToString()
        End Get

    End Property

    Sub Add()
        ' _model.result = _model.Input1 + _model.Input2
        _model.Sum()
    End Sub




    Sub New(_model As CalculatorModel)
        Me._model = _model

    End Sub

    Sub HandlePropertyChanged()

    End Sub
End Class
