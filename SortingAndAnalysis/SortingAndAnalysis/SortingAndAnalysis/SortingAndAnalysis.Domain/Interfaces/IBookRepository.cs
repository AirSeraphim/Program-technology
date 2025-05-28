using System;
using System.Collections.Generic;
using SortingAndAnalysis.Domain.Models;

namespace SortingAndAnalysis.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностью Book.
    /// Реализует основные операции CRUD.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Получить все книги из базы данных.
        /// </summary>
        /// <returns>Список всех книг</returns>
        IEnumerable<Book> GetAll();

        /// <summary>
        /// Получить книгу по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Книга или null, если не найдена</returns>
        Book GetById(Guid id);

        /// <summary>
        /// Добавить новую книгу в хранилище.
        /// </summary>
        /// <param name="book">Книга для добавления</param>
        void Add(Book book);

        /// <summary>
        /// Обновить информацию о существующей книге.
        /// </summary>
        /// <param name="book">Обновлённая книга</param>
        void Update(Book book);

        /// <summary>
        /// Удалить книгу по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        void Delete(Guid id);
    }
}