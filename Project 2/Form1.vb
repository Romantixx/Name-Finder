Public Class Form1
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim inputName As String = txtName.Text.Trim()

        If inputName.Count(Function(c) c = " "c) = 1 Then
            Dim formattedName As String = FormatName(inputName)
            lstNames.Items.Add(formattedName)
            txtName.Clear()
        Else
            MessageBox.Show("Enter name as: FirstName LastName", "Invalid Format")
        End If
    End Sub

    Private Function FormatName(fullName As String) As String
        Dim parts() As String = fullName.Split(" "c)
        Dim first As String = parts(0)
        Dim last As String = parts(1)
        Return last & ", " & first
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstNames.SelectedIndex >= 0 Then
            lstNames.Items.RemoveAt(lstNames.SelectedIndex)
        Else
            MessageBox.Show("Select a name to delete.")
        End If
    End Sub

    Private Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnGet.Click
        If lstNames.SelectedIndex >= 0 Then
            Dim selectedName As String = lstNames.SelectedItem.ToString()
            Dim normalName As String = ConvertToFirstLast(selectedName)
            MessageBox.Show("Original Name: " & normalName)
        Else
            MessageBox.Show("Select a name to get.")
        End If
    End Sub


    Private Function ConvertToFirstLast(formattedName As String) As String
        Dim parts() As String = formattedName.Split(","c)
        Dim last As String = parts(0).Trim()
        Dim first As String = parts(1).Trim()
        Return first & " " & last
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim inputLastName As String = InputBox("Enter last name to search:")

        If inputLastName = "" Then Exit Sub

        Dim found As Boolean = SearchLastName(inputLastName.Trim())
        If found Then
            MessageBox.Show("Last name FOUND in the list.", "Search Result")
        Else
            MessageBox.Show("Last name NOT found.", "Search Result")
        End If
    End Sub

    Private Function SearchLastName(lastName As String) As Boolean
        For Each item As String In lstNames.Items
            Dim currentLastName As String = item.Split(","c)(0).Trim()
            If String.Equals(currentLastName, lastName, StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
        Next
        Return False
    End Function
End Class
