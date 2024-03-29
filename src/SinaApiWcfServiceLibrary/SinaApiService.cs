﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Web;
namespace SinaApiWcfServiceLibrary
{
    // 注意: 如果更改此处的类名 "SinaApiService"，也必须更新 Web.config 中对 "SinaApiService" 的引用。
    public class SinaApiService : oAuthSina,ISinaApiService
    {
        //private oAuthSina _oauth = new oAuthSina();
        public bool oAuth(string userid, string passwd,oAuthSina _oauth)
        {
            try
            {
                string authLink = _oauth.AuthorizationSinaGet();
                authLink += "&userId=" + userid + "&passwd=" + passwd + "&action=submit&oauth_callback=none";
                string html = _oauth.WebRequest(oAuthSina.Method.POST, authLink, null);
                string pin = ParseHtml(html);
                _oauth.Verifier = pin;
                _oauth.AccessTokenGet(_oauth.Token);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /**********************************************************************************************
         *************************************下行数据获取*********************************************
         **********************************************************************************************
         **********************************************************************************************/

        /*最新公共微博*/
        public string public_timeline(string userid, string passwd, string format)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/statuses/public_timeline." + format;
                return _oauth.oAuthWebRequest(oAuthSina.Method.GET, url, String.Empty);
            }
            else
                return null;
        }
        /*最新关注人微博*/
        public string friend_timeline(string userid, string passwd, string format)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/statuses/friends_timeline." + format;
                return _oauth.oAuthWebRequest(oAuthSina.Method.GET, url, String.Empty);
            }
            else
                return null;
        }

        /*用户发表微薄列表*/
        public string user_timeline(string userid, string passwd, string format)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/statuses/user_timeline." + format;
                return _oauth.oAuthWebRequest(oAuthSina.Method.GET, url, String.Empty);
            }
            else
                return null;
        }
        /*最新n条@我的微博*/
        public string mentions(string userid, string passwd, string format)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/statuses/mentions." + format;
                return _oauth.oAuthWebRequest(oAuthSina.Method.GET, url, String.Empty);
            }
            else
                return null;
        }
        /*最新评论*/
        public string comments_timeline(string userid, string passwd, string format)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/statuses/comments_timeline." + format;
                return _oauth.oAuthWebRequest(oAuthSina.Method.GET, url, String.Empty);
            }
            else
                return null;
        }
        /*发出的评论*/
        public string comments_by_me(string userid, string passwd, string format)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/statuses/comments_by_me." + format;
                return _oauth.oAuthWebRequest(oAuthSina.Method.GET, url, String.Empty);
            }
            else
                return null;
        }
        /* 单条评论列表*/
        public string comments(string userid, string passwd, string id, string format)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/statuses/comments." + format + "?id=" + id;
                return _oauth.oAuthWebRequest(oAuthSina.Method.GET, url, String.Empty);
            }
            else
                return null;
        }
        /*批量获取一组微博的评论数及转发数*/
        public string counts(string userid, string passwd, string format, string ids)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/statuses/counts." + format + "?ids=" + ids;
                return _oauth.oAuthWebRequest(oAuthSina.Method.GET, url, String.Empty);
            }
            else
                return null;
        }
        /**********************************************************************************************
         *************************************微博访问接口*********************************************
         **********************************************************************************************
         **********************************************************************************************/
        /*获取单条ID的微博信息*/
        public string statuses_show(string userid, string passwd, string format, string id)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/statuses/show/" + id + "." + format;
                return _oauth.oAuthWebRequest(oAuthSina.Method.GET, url, String.Empty);
            }
            else
                return null;
        }
        /*获取单条ID的微博信息*/
        public string statuses_id(string userid, string passwd, string id, string uid)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/" + uid + "/statuses/" + id;
                return _oauth.oAuthWebRequest(oAuthSina.Method.GET, url, String.Empty);
            }
            else
                return null;
        }
        /*发布一条微博信息*/
        public string statuses_update(string userid, string passwd, string format, string status)
        {
            oAuthSina _oauth = new oAuthSina();
            if (oAuth(userid, passwd, _oauth))
            {
                string url = "http://api.t.sina.com.cn/statuses/update." + format + "?";
                return _oauth.oAuthWebRequest(oAuthSina.Method.POST, url, "status=" + HttpUtility.UrlEncode(status));
            }
            else
                return null;
        }

    }
}
