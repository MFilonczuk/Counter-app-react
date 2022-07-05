using CounterAPI.Entities;

namespace CounterAPI.Services
{
    public interface ICountRepository
    {
        /// <summary>
        /// Pobieranie liczby na strone
        /// </summary>
        /// <returns> Aktualna liczba </returns>
        public Task<Count> GetNumberAsync();


        /// <summary>
        /// Pobieranie liczby o zadanym ID
        /// </summary>
        /// <returns>Zwraca liczbę o zadanym ID </returns>
        public Task<Count> GetNumberByIdAsync(int id);

        /// <summary>
        /// Aktualizacja zadanego obiektu Count
        /// </summary>
        /// <returns> Aktualizuje do bazy danych  </returns>
        public Count UpdateNumber(Count numberToUpdate);


        /// <summary>
        /// Usuwanie liczby po ID
        /// </summary>
        /// <returns></returns>
        public Task DeleteNumberByIdAsync(int id);


        /// <summary>
        /// Dodaje liczbę do bazy danych
        /// </summary>
        /// <returns></returns>
        public Task<Count> AddNumberAsync(Count newNumber);


    }
}
