//-----------------------------------------------------------------------------
// <copyright file="PersonTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.IO;
using NUnit.Framework;

namespace Ucu.Poo.Persons.Tests;

/// <summary>
/// Tests para la clase <see cref="Person"/>.
/// </summary>
public class PersonTests
{
    /// <summary>
    /// Prueba getters y setters de la clase <see cref="Person"/>.
    /// </summary>
    [Test]
    public void TestProperties()
    {
        const string name = "Nombre Apellido";

        Person person = new Person(name, "1234567-2");

        Assert.That(person.Name, Is.EqualTo(name));

        const string anotherName = "John Doe";

        person.Name = anotherName;

        Assert.That(person.Name, Is.EqualTo(anotherName));
    }

    /// <summary>
    /// Prueba que no se puedan asignar string vacías o null a las
    /// propiedades de la clase <see cref="Person"/>.
    /// </summary>
    [Test]
    public void TestNullAndEmptyNameAndFamilyName()
    {
        const string name = "Nombre Apellido";

        Person person = new Person(name, "1234567-2");

        person.Name = null;

        Assert.AreEqual(name, person.Name);

        person.Name = string.Empty;

        Assert.AreEqual(name, person.Name);
    }

    /// <summary>
    /// Prueba el método <see cref="Person.IntroduceTo"/>.
    /// </summary>
    [Test]
    public void TestIntroduceTo()
    {
        const string name = "One";
        const string anotherName = "Two";
        const string hi = "Hola, Two, mi nombre es One";

        Person one = new Person(name, "1234567-2");
        Person two = new Person(anotherName, "1234567-2");

        using (var consoleContent = new StringWriter())
        {
            Console.SetOut(consoleContent);

            one.IntroduceTo(two);

            Assert.That(consoleContent.ToString(), Does.Contain(hi));
        }
    }
}
