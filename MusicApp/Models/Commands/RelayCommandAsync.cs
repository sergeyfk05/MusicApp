﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.Models.Commands
{
    public class RelayCommandAsync : BaseCommand, ICommand
    {
        private readonly Func<Task> execute;

        /// <summary>
        /// Создает новую команду, которая всегда может выполняться.
        /// </summary>
        /// <param name="execute">Логика выполнения.</param>
        public RelayCommandAsync(Func<Task> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Создает новую команду.
        /// </summary>
        /// <param name="execute">Логика выполнения.</param>
        /// <param name="canExecute">Логика состояния выполнения.</param>
        public RelayCommandAsync(Func<Task> execute, Func<bool> canExecute)
            :base(canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this.execute = execute;
        }

        /// <summary>
        /// Выполняет <see cref="RelayCommandAsync"/> текущей цели команды.
        /// </summary>
        /// <param name="parameter">
        /// Данные, используемые командой. Если команда не требует передачи данных, этот объект можно установить равным NULL.
        /// </param>
        public async void Execute(object parameter = null)
        {
            if (CanExecute())
                await execute();
        }
    }
}