﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Mt.Utilities
{
	/// <summary>
	/// Класс для упрощения проверки аргументов функций.
	/// </summary>
	public static class Check
    {
		/// <summary>
		/// Проверка строки на пустое значение или null.
		/// </summary>
		/// <param name="value">Значение строки.</param>
		/// <param name="parameterName">Название параметра.</param>
		/// <param name="message">Сообщение об ошибке.</param>
		/// <returns>Входная строкаы.</returns>
		/// <exception cref="ArgumentException">Строка принимает пустое значение.</exception>
		/// <exception cref="ArgumentNullException">Строка принимает значение равное null.</exception>
		public static string NotEmpty(string value, [NotNull] string parameterName, string message = null)
		{
			if (value is null)
			{
				Check.NotEmpty(parameterName, nameof(parameterName));
				throw new ArgumentNullException(parameterName, string.IsNullOrWhiteSpace(message) ? $"Checked parameter is null." : message);
			}
			
			if (value.Trim().Length is 0)
			{
				Check.NotEmpty(parameterName, nameof(parameterName));
				throw new ArgumentException(string.IsNullOrWhiteSpace(message) ? $"Checked parameter '{parameterName}' is empty." : message);
			}

			return value;
		}

        /// <summary>
        /// Проверка параметра на пустое значение или null.
        /// </summary>
        /// <typeparam name="T">Шаблон данных.</typeparam>
        /// <param name="value">Значение строки.</param>
        /// <param name="parameterName">Название параметра.</param>
		/// <param name="message">Сообщение об ошибке.</param>
		public static IEnumerable<T> NotEmpty<T>(IEnumerable<T> value, [NotNull] string parameterName, string message = null)
		{
			if (value is null)
			{
                Check.NotEmpty(parameterName, nameof(parameterName));
                throw new ArgumentNullException(parameterName, string.IsNullOrWhiteSpace(message) ? $"Checked parameter is null." : message);
            }

			if(!value.Any())
			{
                Check.NotEmpty(parameterName, nameof(parameterName));
                throw new ArgumentException(string.IsNullOrWhiteSpace(message) ? $"Checked parameter '{parameterName}' is empty." : message);
            }

			return value;
		}

        /// <summary>
        /// Проверка параметра на значение null.
        /// </summary>
        /// <typeparam name="T">Тип параметра.</typeparam>
        /// <param name="value">Значение параметра.</param>
        /// <param name="parameterName">Название параметра.</param>
        /// <param name="message">Сообщение об ошибке.</param>
        /// <returns>Входной параметр.</returns>
        /// <exception cref="ArgumentNullException">Параметр равен null.</exception>
        public static T NotNull<T>(T value, [NotNull] string parameterName, string message = null)
		{
			if (value is null)
			{
				Check.NotEmpty(parameterName, nameof(parameterName), message);
                throw new ArgumentNullException(parameterName, string.IsNullOrWhiteSpace(message) ? $"Checked parameter is null." : message);
            }

			return value;
		}

		/// <summary>
		/// Проверка параметра на значение ноль.
		/// </summary>
		/// <typeparam name="T">Тип параметра.</typeparam>
		/// <param name="value">Значение параметра.</param>
		/// <param name="parameterName">Название параметра.</param>
		/// <param name="message">Сообщение об ошибке.</param>
		/// <returns>Входной параметр.</returns>
		/// <exception cref="ArgumentException">Параметр равен нулю.</exception>
		public static T NotZero<T>(T value, [NotNull] string parameterName, string message = null)
			where T : struct
		{
			var zero = default(T);
			if (value.Equals(zero))
			{
				Check.NotEmpty(parameterName, nameof(parameterName), message);
				throw new ArgumentException(message ?? $"Input parameter '{parameterName}' is zero value.");
			}

			return value;
		}

		/// <summary>
		/// Проверка параметра на принадлежность интервалу.
		/// </summary>
		/// <param name="value">Значение параметра.</param>
		/// <param name="parameterName">Название параметра.</param>
		/// <param name="minValue">Минимальное значение.</param>
		/// <param name="maxValue">Максимальное значение.</param>
		/// <returns>Входной параметр.</returns>
		/// <exception cref="ArgumentException">При неверном задении интервала.</exception>
		public static int FromInterval(int value, [NotNull] string parameterName, int minValue, int maxValue)
        {
            if ((long)maxValue - minValue <= 0)
			{
				throw new ArgumentException($"Интервал значений для проверки параметра задан неверно [min:{minValue}; max:{maxValue}].");
			}

			if (!(minValue <= value && value <= maxValue))
			{
				Check.NotEmpty(parameterName, nameof(parameterName));
				throw new ArgumentException($"Параметр '{parameterName}':{value}∉[min:{minValue}; max:{maxValue}].");
			}

			return value;
		}
	}
}