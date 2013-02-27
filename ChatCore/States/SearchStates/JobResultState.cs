﻿using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States.SearchStates
{
    class JobResultState : BaseSearchState
    {
        public override void HandleMsg(TalkSession session, Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Content))
            {
                if (msg.Content == "1")
                {
                    Search.PageIndex++;
                    session.State = new JobResultState() { Search = Search };
                }
                else
                {
                    if (msg.Content == "Search")
                        session.State = new SearchStartStates();
                    else if (msg.Content == "profile")
                        session.State = new UserProfileStates.UserProfileState();
                }
            }
        }

        public override string Content
        {
            get
            {
                IJobRepositary repositary = new JobRepositaryByAPI();
                var results = repositary.Search(new JobSearchQuery()
                {
                    KeyWord = Search.Keyword,
                    Location = Search.Location,
                    PageSize = 3,
                    StartIndex = Search.PageIndex * 3
                });
                //return string.Format("KeyWord:{0},Location{1},Page:{2}", Search.Keyword, Search.Location, Search.PageIndex);
                var sb = new StringBuilder();
                foreach (var t in results)
                {
                    sb.AppendFormat("Title:{0}\nDID:{1}", t.JobTitle, t.DID);
                }
                return sb.ToString();
            }
        }
    }
}