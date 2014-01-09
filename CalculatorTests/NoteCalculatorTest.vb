Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Ninject
Imports VBMVVMCalculator
Imports System.Net.Fakes
Imports Microsoft.QualityTools.Testing.Fakes
Imports System.IO
Imports Newtonsoft.Json.Fakes
<TestClass()> Public Class NoteCalculatorTest
    Private kernel As New StandardKernel()
    <TestInitialize> Sub NoteCalculatorTestInit()
        kernel.Bind(Of ICalculatorModel).To(Of NoteCalculator)()
        kernel.Bind(Of INoteProductionGetter).To(Of NoteProductionGetter)()
    End Sub
    <TestMethod()> Public Sub NoteCalculator_Calculate_should_populate_result()
        'arrange
        Dim object_under_test = kernel.Get(Of NoteCalculator)()
        object_under_test.Input1 = 2009
        object_under_test.Input2 = 5

        'act
        object_under_test.Calculate()
        'assert
        Assert.IsNotNull(object_under_test.result)
    End Sub


    <TestMethod()> Public Sub NoteCalculator_FY2009_Produced_716800000_20Bills()
        'arrange
            Dim object_under_test = kernel.Get(Of NoteCalculator)()
            'act
            object_under_test.Input1 = 2009
            object_under_test.Input2 = 20
            Dim expected = 716800000
            object_under_test.Calculate()
            'assert
            Assert.AreEqual(object_under_test.result, expected)

    End Sub

    <TestMethod()> Public Sub ShimmedNoteCalculator_FY2009_Produced_716800000_20Bills()
        'arrange
        Using (ShimsContext.Create())
            ShimHttpWebRequest.AllInstances.GetResponse() = Function(req)
                                                                Return New ShimHttpWebResponse()
                                                            End Function
            ShimHttpWebResponse.AllInstances.GetResponseStream() =
                Function(r)
                    Return New MemoryStream()
                End Function
            ShimJsonConvert.DeserializeObjectOf1String(Of RootObject())(
                Function(s)
                    Return New RootObject() {New RootObject With {.fiscal_year = "FY 2009", ._20_bills = "716800000"}}
                End Function
            )

            Dim object_under_test = kernel.Get(Of NoteCalculator)()
            'act
            object_under_test.Input1 = 2009
            object_under_test.Input2 = 20
            Dim expected = 716800000
            object_under_test.Calculate()
            'assert
            Assert.AreEqual(object_under_test.result, expected)

        End Using
    End Sub
End Class
