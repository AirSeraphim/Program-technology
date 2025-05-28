using System;
using System.Collections.Generic;
using SortingAndAnalysis.Domain.Models;

namespace SortingAndAnalysis.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с задачами анализа.
    /// </summary>
    public interface IAnalysisTaskRepository
    {
        /// <summary>
        /// Получить все задачи анализа.
        /// </summary>
        /// <returns>Список задач</returns>
        IEnumerable<AnalysisTask> GetAll();

        /// <summary>
        /// Получить задачу по ID.
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <returns>Задача или null, если не найдена</returns>
        AnalysisTask GetById(Guid id);

        /// <summary>
        /// Добавить новую задачу.
        /// </summary>
        /// <param name="task">Задача для добавления</param>
        void Add(AnalysisTask task);

        /// <summary>
        /// Обновить существующую задачу.
        /// </summary>
        /// <param name="task">Обновлённая задача</param>
        void Update(AnalysisTask task);

        /// <summary>
        /// Удалить задачу по ID.
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        void Delete(Guid id);
    }
}