using SkillsTask.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SkillsTask
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Skill>().Wait();
           
        }

        public ObservableCollection<Skill> GetSkillsAsync()
        {
            var skills = _database.Table<Skill>().ToListAsync();
            return new ObservableCollection<Skill>(skills.Result);
            
        }

        public Task<int> SaveSkillAsync(Skill skill)
        {
            return _database.InsertAsync(skill);
        }

        public string UpdateSkill(Skill skill)
        {
            _database.UpdateAsync(skill);
            return "success";
        }
        //public Skill UpdateSkill(Skill skill)
        //{
        //    var updated = _database.FindAsync<Skill>(s => s.ID == skill.ID).Result;
        //    updated.Name = skill.Name;
        //    updated.Level = skill.Level;
        //    updated.Descritpion = skill.Descritpion;
        //    return updated;

        //}
        //public Task<int> DeleteSkillsAsync()
        //{
        //    return _database.DeleteAllAsync<Skill>();
        //}
    }
}
