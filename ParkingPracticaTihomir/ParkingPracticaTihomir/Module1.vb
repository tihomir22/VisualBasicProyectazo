Module Module1

    Sub Main()





        Dim opcion As Int32 = 999
        Dim eleccion As Int32
        Dim actualPosicion As Int32 = 0
        Dim ruta As String = ""

        Dim vehiculo1 = New Vehiculo("1018HJK", "Pepe", "Banano", Now.ToString())
        Dim vehiculo2 = New Vehiculo("8308XZR", "Josh", "Pepito", Now.ToString())
        Dim vehiculo3 = New Vehiculo("1234XRG", "Tihomir", "Stoychev", Now.ToString())
        Dim vehiculo4 = New Vehiculo("9831XZR", "Andreu", "Figuer", Now.ToString())
        Dim vehiculo5 = New Vehiculo("9018HJK", "Deus", "Vult", Now.ToString())


        Dim todosLosVehiculos = {vehiculo1, vehiculo2, vehiculo3, vehiculo4, vehiculo5}.ToList
        Dim parking = {vehiculo1}.ToList
        parking.Clear()

        Do While opcion <> 0
            mostrarMenu()
            opcion = Console.ReadLine()
            Select Case opcion
                Case 1
                    Console.WriteLine("Elige un vehiculo a aparcar")
                    mostrarVehiculos(todosLosVehiculos.ToArray)
                    eleccion = Console.ReadLine()
                    If (eleccion < todosLosVehiculos.ToArray.Length) Then
                        If (actualPosicion < 4) Then
                            parking.Add(todosLosVehiculos(eleccion))
                            Console.WriteLine("Añadido exitosamente el vehiculo " & todosLosVehiculos(eleccion).toString)
                            actualPosicion = actualPosicion + 1
                            Console.WriteLine("El parking ahora tiene " & actualPosicion & "de 4")
                        Else
                            Console.WriteLine("El parking esta lleno no se pueden añadir más")
                        End If
                    Else
                        Console.WriteLine("Has introducido un numero incorrecto")
                    End If
                Case 2
                    Console.WriteLine("Elige un vehiculo a sacar del parking")
                    mostrarParking(parking.ToArray)
                    eleccion = Console.ReadLine()
                    If (eleccion < actualPosicion And eleccion < parking.ToArray.Length) Then
                        parking.RemoveAt(eleccion)
                        Console.WriteLine("Eliminado con exito!")
                        mostrarParking(parking.ToArray)
                    Else
                        Console.WriteLine("No introduciste un numero correcto")
                    End If
                Case 3
                    Try
                        Console.WriteLine("Introduce la ruta del fichero destino o dejalo en blanco para usar la por defecto")
                        ruta = Console.ReadLine
                        If (ruta.Length = 0) Then
                            ruta = "ficheroDestino.txt"
                        End If

                        guardarDatosFichero(ruta)
                        Console.WriteLine("Escrito con exito")
                    Catch ex As Exception
                        Console.WriteLine(ex.ToString)

                    End Try
                Case 4
                    Try
                        Console.WriteLine("Introduce la ruta del fichero destino o dejalo en blanco para usar la por defecto")
                        ruta = Console.ReadLine
                        If (ruta.Length = 0) Then
                            ruta = "ficheroDestino.txt"
                        End If

                        cargarDatosFichero(ruta)
                        Console.WriteLine("Leido con exito")
                    Catch ex As Exception
                        Console.WriteLine(ex.ToString)

                    End Try




            End Select
        Loop






    End Sub

    Structure Vehiculo
        Dim matricula As String
        Dim nombreProp As String
        Dim apellidosProp As String
        Dim fecha As String
        Private v1 As String
        Private v2 As String
        Private v3 As String
        Private v4 As String

        Public Sub New(v1 As String, v2 As String, v3 As String, v4 As String)
            Me.New()
            Me.v1 = v1
            Me.v2 = v2
            Me.v3 = v3
            Me.v4 = v4
        End Sub

        Function toString()
            Return (v1 + " " + v2 + " " + v3 + " " + v4)
        End Function


    End Structure

    Function mostrarMenu()
        Console.WriteLine("1.Entrada del vehiculo")
        Console.WriteLine("2.Salida del vehiculo")
        Console.WriteLine("3.Guardar vehiculos en ficheros")
        Console.WriteLine("4.-Cargar vehiculos desde ficheros a array 'todosLosVehiculos'")
    End Function

    Function mostrarVehiculos(ByVal array() As Vehiculo)
        For Index As Int32 = 0 To array.Length - 1
            Console.WriteLine("[" & Index & "] " & array(Index).toString)
        Next
    End Function

    Function mostrarParking(ByVal array() As Vehiculo)
        For Index As Int32 = 0 To array.Length - 1
            Console.WriteLine("[" & Index & "] " & array(Index).toString)
        Next
    End Function

    Function guardarDatosFichero(ByVal ruta As String)
        Dim vehiculo1 = New Vehiculo("1018HJK", "Pepe", "Banano", Now.ToString())
        Dim vehiculo2 = New Vehiculo("8308XZR", "Josh", "Pepito", Now.ToString())
        Dim vehiculo3 = New Vehiculo("1234XRG", "Tihomir", "Stoychev", Now.ToString())
        Dim vehiculo4 = New Vehiculo("9831XZR", "Andreu", "Figuer", Now.ToString())
        Dim vehiculo5 = New Vehiculo("9018HJK", "Deus", "Vult", Now.ToString())

        Dim Fichero As Integer = FreeFile()
        FileOpen(Fichero, ruta, OpenMode.Output)
        WriteLine(Fichero, vehiculo1.toString)
        WriteLine(Fichero, vehiculo2.toString)
        WriteLine(Fichero, vehiculo3.toString)
        WriteLine(Fichero, vehiculo4.toString)
        WriteLine(Fichero, vehiculo5.toString)
        FileClose(Fichero)


    End Function

    Function cargarDatosFichero(ByVal ruta As String)

        Dim TextoLeido As String = ""
        Dim Fichero As Integer = FreeFile()
        FileOpen(Fichero, ruta, OpenMode.Input)
        Do While EOF(Fichero) = False
            Dim DatosLeidos As String = ""
            Input(Fichero, DatosLeidos)
            TextoLeido = TextoLeido & DatosLeidos & "|"

        Loop
        Dim arrayLeido() As String = TextoLeido.Split("|")
        FileClose(Fichero)
        ReDim Preserve arrayLeido(arrayLeido.Length - 2)
        Console.WriteLine("El array tiene " & arrayLeido.Length)

        For Index As Int32 = 0 To arrayLeido.Length - 1
            Console.WriteLine(arrayLeido(Index).ToString)
        Next

        Return TextoLeido

    End Function



End Module
