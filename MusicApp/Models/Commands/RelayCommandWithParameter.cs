﻿using System;
using System.Windows.Input;

namespace MusicApp.Models.Commands
{
    public class RelayCommandWithParameter<T> : BaseCommand, ICommand
    {
        private readonly Action<T> execute;

        /// <summary>
        /// Создает новую команду, которая всегда может выполняться.
        /// </summary>
        /// <param name="execute">Логика выполнения.</param>
        public RelayCommandWithParameter(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Создает новую команду.
        /// </summary>
        /// <param name="execute">Логика выполнения.</param>
        /// <param name="canExecute">Логика состояния выполнения.</param>
        public RelayCommandWithParameter(Action<T> execute, Func<bool> canExecute)
            :base(canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this.execute = execute;
        }

        /// <summary>
        /// Выполняет <see cref="RelayCommandWithParameter{T}"/> текущей цели команды.
        /// </summary>
        /// <param name="parameter">
        /// Данные, используемые командой. Если команда не требует передачи данных, этот объект можно установить равным NULL.
        /// </param>
        public void Execute(object parameter)
        {
            if ((parameter != null) && (CanExecute(parameter)))
                execute?.BeginInvoke((T)parameter, null, null);
        }
    }
}
