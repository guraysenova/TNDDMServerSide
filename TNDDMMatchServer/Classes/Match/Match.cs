using System;
using System.Collections.Generic;
using TNDDMMatchServer.Classes;
using TNDDMMatchServer.Classes.GameScripts;

namespace TNDDMMatchServer
{
    class Match
    {
        List<Team> teams = new List<Team>();
        MatchData matchData = null;
        public Game Game { get; }

        bool matchStarted = false;

        public Match(string roomUUID , string playerOneUUID , string playerOneToken , string playerOneName, string playerTwoUUID, string playerTwoToken, string playerTwoName)
        {
            matchData = new MatchData(roomUUID);

            PlayerLoginData playerOne = new PlayerLoginData(playerOneUUID, playerOneToken, playerOneName , PlayerEnum.Player1 , TeamEnum.Team1);
            PlayerLoginData playerTwo = new PlayerLoginData(playerTwoUUID, playerTwoToken, playerTwoName , PlayerEnum.Player2 , TeamEnum.Team2);

            Team teamOne = new Team(new Player(playerOne) , TeamEnum.Team1);
            Team teamTwo = new Team(new Player(playerTwo) , TeamEnum.Team2);

            teams.Add(teamOne);
            teams.Add(teamTwo);

            Game = new Game(teams);
        }


        public bool IsCorrectToken(string roomUUID ,string playerUUID , string playerToken)
        {
            bool isCorrect = false;

            if (!String.Equals(matchData.MatchUUID, roomUUID))
            {
                return false;
            }
            foreach (Team team in teams)
            {
                foreach (Player player in team.Players)
                {
                    if(String.Equals(player.UUID , playerUUID) && String.Equals(player.Token, playerToken))
                    {
                        return true;
                    }
                }
            }

            return isCorrect;
        }

        public void SetReady(string playerUUID , int id)
        {
            Console.WriteLine("start Set true " + id);
            foreach (Team team in teams)
            {
                foreach (Player player in team.Players)
                {
                    Console.WriteLine("Player UUID = " + player.UUID + "  our uuid was = " + playerUUID);
                    if (String.Equals(player.UUID, playerUUID))
                    {
                        player.ID = id;
                        player.IsReady = true;
                        Console.WriteLine("Set true " + id);
                    }
                }
            }
            Console.WriteLine(IsMatchReady());
            if (IsMatchReady() && !matchStarted)
            {
                MatchStart();
            }
        }

        bool IsMatchReady()
        {
            foreach (Team team in teams)
            {
                foreach (Player player in team.Players)
                {
                    if (!player.IsReady)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        void MatchStart()
        {
            if (matchStarted)
            {
                return;
            }
            foreach (var team in teams)
            {
                foreach (var player in team.Players)
                {
                    ServerSend.MatchStarted(player.ID, (int)player.TeamEnum, (int)player.PlayerEnum, teams);
                }
            }
            matchStarted = true;
        }
        // TODO: START A GAME AND STUFF
    }
}
