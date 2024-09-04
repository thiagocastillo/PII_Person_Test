//-------------------------------------------------------------------------
// <copyright file="Person.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------
using System;

namespace Ucu.Poo.Persons;

/// <summary>
/// Esta clase representa una persona con clase y apellido.
/// </summary>
public class Person
{
    private string name;

    private string id;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Person"/> con
    /// el nombre y la cédula —id— recibidos como argumento.
    /// </summary>
    /// <param name="name">El nombre completo de la persona.</param>
    /// <param name="id">La cédula de la persona.</param>
    public Person(string name, string id)
    {
        this.id = id;
        this.Name = name;
    }

    /// <summary>
    /// Obtiene o establece el nombre de la persona. El nombre se puede
    /// establecer sólo si no está en blanco.
    /// </summary>
    /// <value>El nombre de la persona.</value>
    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                this.name = value;
            }
        }
    }

    /// <summary>
    /// Obtiene o establece la cédula —id— de la persona. La cédula se puede
    /// establecer solo si es válida.
    /// </summary>
    public string Id
    {
        get
        {
            return this.id;
        }

        set
        {
            if (!IdUtils.IdIsValid(value))
            {
                this.id = value;
            }
        }
    }

    /// <summary>
    /// Esta persona se presenta con otra.
    /// </summary>
    /// <param name="person">La persona a la cual presentarse.</param>
    public void IntroduceTo(Person person)
    {
        if (person != null)
        {
            Console.WriteLine($"Hola, {person.Name}, mi nombre es {this.Name}");
        }
    }
}
