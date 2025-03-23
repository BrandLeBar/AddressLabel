'Brandon Barrera
'RCET0265
'Spring 2025
'Address Label Program
'

Option Compare Text
Option Explicit On
Option Strict On

Public Class AddressLabelForm

    Sub SetDefaults()
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""
        DisplayLabel.Text = ""
    End Sub

    'Event Handlers ***********************************************************

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        SetDefaults()
    End Sub

    Private Sub DisplayLabelButton_Click(sender As Object, e As EventArgs) Handles DisplayLabelButton.Click
        Try

            If UserInputIsValid() Then
                DisplayLabel.Text = ($"{FirstNameTextBox.Text} {LastNameTextBox.Text _
                } {vbNewLine}{StreetAddressTextBox.Text} {vbNewLine _
                }{CityTextBox.Text}, {StateTextBox.Text} {ZipTextBox.Text}")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Function UserInputIsValid() As Boolean
        Dim valid As Boolean = True
        Dim message As String

        If IsNumeric(ZipTextBox.Text) = False Then
            valid = False
            ZipTextBox.Focus()
            message &= "Please enter a valid zip code." & vbNewLine
        End If

        If StateTextBox.Text = "" Then
            valid = False
            StateTextBox.Focus()
            message &= "Please enter a state." & vbNewLine
        End If

        If CityTextBox.Text = "" Then
            valid = False
            CityTextBox.Focus()
            message &= "Please enter a city." & vbNewLine
        End If

        If FirstNameTextBox.Text = "" Then
            valid = False
            FirstNameTextBox.Focus()
            message &= "Please enter a first name." & vbNewLine
        End If

        If LastNameTextBox.Text = "" Then
            valid = False
            LastNameTextBox.Focus()
            message &= "Please enter a last name." & vbNewLine
        End If

        If Not valid Then
            MsgBox(message, MsgBoxStyle.Critical, "User input fail!!!! >:( ")
        End If

        Return valid
    End Function

End Class
