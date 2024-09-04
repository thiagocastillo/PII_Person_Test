//-------------------------------------------------------------------------
// <copyright file="IdUtils.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------
using System;
using System.Globalization;
using System.Linq;

namespace Ucu.Poo.Persons;

/// <summary>
/// Esta clase valida cédulas de identidad.
/// </summary>
public static class IdUtils
{
    /// <summary>
    /// Valida un número de cédula de identidad; el número puede tener o no puntos y el guión pero debe tener el dígito verificador. Adaptado
    /// de https://es.wikipedia.org/wiki/C%C3%A9dula_de_Identidad_de_Uruguay#Match_on_Card.
    /// </summary>
    /// <param name="id">El número de cédula.</param>
    /// <returns>Retorna true si el número de cédula es válido y false en caso contrario.</returns>
    public static bool IdIsValid(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return false;
        }

        long tempOut;

        // Quitar puntos y guiones
        id = id.Replace(".", string.Empty, StringComparison.InvariantCulture);
        id = id.Replace("-", string.Empty, StringComparison.InvariantCulture);

        // Validar largo
        if (id.Length == 8 && long.TryParse(id, out tempOut))
        {
            var idAsCharArray = id.ToArray();
            var idAsIntArray = idAsCharArray.Select(c => int.Parse(c.ToString(), CultureInfo.InvariantCulture)).ToArray();
            var referenceArray = "2987634".ToArray().Select(c => int.Parse(c.ToString(), CultureInfo.InvariantCulture)).ToArray();
            var inputCheckDigit = idAsIntArray[7];

            // Calcular número verificador
            int checkSum = 0;
            for (int i = 0; i < referenceArray.Length; i++)
            {
                checkSum = checkSum + (idAsIntArray[i] * referenceArray[i]);
            }

            int checkDigit = 10 - (checkSum % 10);

            if (checkDigit == 10)
            {
                checkDigit = 0;
            }

            if (checkDigit != inputCheckDigit)
            {
                // Número verificador ingresado inválido
                return false;
            }
        }
        else
        {
            // Formato de cédula de identidad inválido
            return false;
        }

        return true;
    }
}
