Public Class Form1

    Dim Blocks As Integer
    Dim BlockEmeralds As Integer
    Dim Emeralds As Double
    Dim TotalEmeralds As Integer
    Dim Rads As Double
    Dim DoEmeralds As Boolean

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        'Emeralds to Radiants
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
            CheckBox1.Checked = False
            CheckBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        'Radiants to Emeralds
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
            CheckBox1.Enabled = True
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click


        If RadioButton1.Checked = True Then 'Emeralds to Rads
            Dim Valid As Boolean

            If TextBox1.Text.ToString = "" Then
                Blocks = 0
                TextBox4.AppendText("Emerald Blocks: " + Blocks.ToString + vbCrLf)
            Else
                Valid = vbNull
                Valid = Int32.TryParse(TextBox1.Text, Blocks)
                If Valid = True Then
                    Blocks = Int32.Parse(TextBox1.Text)
                    TextBox4.AppendText("Emerald Blocks: " + Blocks.ToString + vbCrLf)
                ElseIf Valid = False Then
                    MsgBox("You must input an integer value into the Emerald Block Field.", MsgBoxStyle.Exclamation, "Integer value required")
                End If
            End If

            If TextBox2.Text.ToString = "" Then
                Emeralds = 0
                TextBox4.AppendText("Emeralds: " + Emeralds.ToString + vbCrLf)
            Else
                Valid = vbNull
                Valid = Int32.TryParse(TextBox2.Text, Emeralds)
                If Valid = True Then
                    Emeralds = Int32.Parse(TextBox2.Text)
                    TextBox4.AppendText("Emeralds: " + Emeralds.ToString + vbCrLf)
                ElseIf Valid = False Then
                    MsgBox("You must input an integer value into the Emerald field.", MsgBoxStyle.Exclamation, "Integer value required")
                End If
            End If

            'If Int32.TryParse(TextBox1.Text, Blocks) = True Then
            'If Int32.TryParse(TextBox2.Text, Emeralds) = True Then
            BlockEmeralds = Math.BigMul(Blocks, 9)

            TextBox4.AppendText(Blocks.ToString + " times 9 = " + BlockEmeralds.ToString + vbCrLf)
            TotalEmeralds = BlockEmeralds + Emeralds

            TextBox4.AppendText("Total number of Emeralds: " + TotalEmeralds.ToString + vbCrLf)

            TextBox4.AppendText("Multiplying " + TotalEmeralds.ToString + " Emeralds by 20" + vbCrLf)

            Rads = Math.BigMul(TotalEmeralds, 20)

            TextBox3.Text = Rads

            TextBox4.AppendText("Rads: " + Rads.ToString + vbCrLf)
            'End If
            'End If
        End If

        If RadioButton2.Checked = True Then 'Rads to Emeralds
            Dim Valid As Boolean
            Dim Rads As Integer
            Dim Remainder As Integer
            Dim Emeralds As Integer
            Dim Blocks As Integer


            If TextBox3.Text.ToString = "" Then
                Rads = 0
                MsgBox("Please insert the number of Radiants you would like to convert.", MsgBoxStyle.Exclamation, "Insert Radiants")
            Else
                Valid = Int32.TryParse(TextBox3.Text, Rads)

                If Valid = True Then
                    TextBox4.AppendText("Dividing " + Rads.ToString + " Emeralds by 20" + vbCrLf)
                    Emeralds = Math.DivRem(Rads, 20, Remainder)

                    If Remainder = 0 Then
                        TextBox4.AppendText("There are " + Emeralds.ToString + " Emeralds" + vbCrLf)
                    ElseIf Remainder > 0 Then
                        TextBox4.AppendText("There are " + Emeralds.ToString + " Emeralds and " + Remainder.ToString + " Radiants remaining." + vbCrLf)
                    End If

                    If DoEmeralds = True Then
                        Blocks = Math.DivRem(Emeralds, 9, Remainder)
                        TextBox1.Text = Blocks
                        TextBox2.Text = Remainder
                    Else
                        TextBox1.Text = ""
                        TextBox2.Text = Emeralds
                    End If

                ElseIf Valid = False Then
                    MsgBox("You must input an integer value into the Radiants field.", MsgBoxStyle.Exclamation, "Integer value required")
                End If
            End If

        End If





    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        TextBox1.ResetText()
        TextBox2.ResetText()
        TextBox3.ResetText()
        TextBox4.ResetText()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DoEmeralds = True
        ElseIf CheckBox1.Checked = False Then
            DoEmeralds = False
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Dim license = MsgBox("This program is packaged with a Creative Commons 'Attribution-NonCommercial-ShareAlike 4.0 International" + (Chr(13) & Chr(10)) + "(CC BY-NC-SA 4.0)' License." + (Chr(13) & Chr(10)) + (Chr(13) & Chr(10)) + "Information can be found at http://creativecommons.org/licenses/by-nc-sa/4.0/. Would you like to view this page?", MsgBoxStyle.Information & MsgBoxStyle.YesNo, "Licensing")
        If license = MsgBoxResult.Yes Then
            Dim Location As String = "http://creativecommons.org/licenses/by-nc-sa/4.0/"
            Process.Start(Location)
        ElseIf license = MsgBoxResult.No Then
            'Terminate
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox4.AppendText("Author: Devin Duanne (Foxtrek_64)." + vbCrLf)
        TextBox4.AppendText("License: CC BY-NC-SA 4.0 International" + vbCrLf)
    End Sub
End Class
