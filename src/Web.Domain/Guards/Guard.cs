using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Exceptions;

namespace Web.Domain.Guards
{
    public static class CustomGuards
    {
        public static void NotEmptyString(this IGuardClause guardClause, string input, string parameter)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new DomainException($"{parameter} much not empty.");
            }
        }
        public static void BothNotNullEmpty(this IGuardClause guardClause, object? input1, string parameterName1,
            object? input2
            , string parameterName2)
        {
            if (input1 == null && input2 == null)
            {
                throw new DomainException($"Both \"{parameterName1}\" and \"{parameterName2}\" cannot be null or empty.");
            }
        }

        public static void BothNotNull<T>(this IGuardClause guardClause, T? input1, string parameterName1,
            T? input2
            , string parameterName2)
        {
            if (input1 == null && input2 == null)
            {
                throw new DomainException($"Both \"{parameterName1}\" and \"{parameterName2}\" cannot be null or empty.");
            }
        }

        public static void SizeNotGreater(this IGuardClause clause, IFormFile file, long maxSize)
        {
            if (file.Length > maxSize)
            {
                throw new DomainException($"File: \"{file.FileName}\" is too large.");
            }
        }

        public static void DateInRange(this IGuardClause clause, DateTime input, DateTime from, DateTime to)
        {
            if (input < from || input > to)
            {
                throw new DomainException($"Date:{input.ToString(CultureInfo.InvariantCulture)} is not in range: \"{from.ToString(CultureInfo.InvariantCulture)}\" - \"{to.ToString(CultureInfo.InvariantCulture)}\".");
            }
        }

        public static void DateCreaterCurrent(this IGuardClause clause, DateTime date, string parameterName)
        {
            var now = DateTime.UtcNow;

            if (date < now)
            {
                throw new DomainException($"{parameterName} is not valid.");
            }
        }

        public static void DateSmallerCurrent(this IGuardClause clause, DateTime date, string parameterName)
        {
            var now = DateTime.UtcNow;

            if (date > now)
            {
                throw new DomainException($"{parameterName} is not valid.");
            }
        }

        public static void DateGreater(this IGuardClause clause, DateTime date, string parameterName, DateTime dateToCompair)
        {
            if (date < dateToCompair)
            {
                throw new DomainException($"{parameterName} is not valid.");
            }
        }

        public static void DateSmaller(this IGuardClause clause, DateTime date, string parameterName, DateTime dateToCompair)
        {
            if (date > dateToCompair)
            {
                throw new DomainException($"{parameterName} is not valid.");
            }
        }

        public static void AgeGuard(this IGuardClause clause, int? from, int? to)
        {
            if (from == null && to == null) return;
            if (from.HasValue)
            {
                if (from.Value < 18) throw new DomainException("Age much greater 17");
            }
            if (to.HasValue)
            {
                if (to.Value > 60) throw new DomainException("Age much not greater 60");
            }
            if (from.HasValue && to.HasValue)
            {
                if (from.Value > to.Value)
                {
                    throw new DomainException("Age Start cannot greater Age End.");
                }
            }
        }
    }
}
