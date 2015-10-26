﻿Public Class AsignacionKPIs

    Dim formula As List(Of String) = New List(Of String)
    Dim operador As Boolean = False
    Dim detalle As Boolean = True

    Private Sub btnAgregarValor_Click(sender As Object, e As EventArgs)
        armarFormula(txtValor.Text)
        txtValor.Text = ""
    End Sub

    Private Sub btnOperador_Click(sender As Object, e As EventArgs)
        Dim operador = CType(sender, Button).Text
        If (Not operador.Equals("")) Then
            armarFormula(operador)
            txtValor.Text = ""
        End If
    End Sub

    Private Sub armarFormula(dato As String)

        If (operador = False And Not isOperador(dato)) Then
            formula.Add(dato)
            operador = True
        Else
            If (operador = True And isOperador(dato)) Then
                formula.Add(dato)
                operador = False
                detalle = True
            Else
                MessageBox.Show("orden de parametros incorrectos")
            End If
        End If

        txtFormula.Text = ""

        For Each dat As String In formula
            txtFormula.Text += dat
        Next
    End Sub

    Private Sub lstCampo_SelectedIndexChanged(sender As Object, e As EventArgs)
        If (lstCampo.SelectedIndex <> 0) Then
            armarFormula(lstCampo.SelectedItem)
        End If


    End Sub

    Private Function isOperador(dato As String) As Boolean
        Dim resul As Boolean
        If (dato.Equals("+") Or dato.Equals("-") Or dato.Equals("/") Or dato.Equals("*")) Then
            resul = True
        Else
            resul = False
        End If
        Return resul
    End Function

    Private Sub txtValor_TextChanged(sender As Object, e As EventArgs)
        Try
            Convert.ToInt32(txtValor.Text)
        Catch ex As Exception
            txtValor.Text = ""
        End Try
    End Sub
End Class
