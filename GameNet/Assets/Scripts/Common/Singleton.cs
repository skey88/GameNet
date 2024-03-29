﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

 
    public class Singleton<T> where T : new()
    {
        static protected T sInstance;
        static protected bool IsCreate = false;

        public static T Instance
        {
            get
            {
                if (IsCreate == false)
                {
                    CreateInstance();
                }

                return sInstance;
            }
        }

        public static void CreateInstance()
        {
            if (IsCreate == true)
                return;

            IsCreate = true;
            sInstance = new T();
        }

        public static void ReleaseInstance()
        {
            sInstance = default(T);
            IsCreate = false;
        }
    }

    public class SingletonNewFirst<T> where T : SingletonNewFirst<T>
    {
        static protected T sInstance;

        public static T Get()
        {
                if(sInstance == null)
                { 
                    throw new SystemException();
                }
                return sInstance;
        }

        public SingletonNewFirst()
        {
            sInstance = (T)this;
        }

        public static bool haveInstance()
        {
            return sInstance != null;
        }
    }

    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        protected static T sInstance = null;
        protected static bool IsCreate = false;
        public static bool s_debugDestroy = false;
        public static T Instance
        {
            get
            {
                if (s_debugDestroy)
                {
                    return null;
                }
                CreateInstance();
                return sInstance;
            }
        }

        protected virtual void Awake()
        {
            if (sInstance == null)
            {
                sInstance = this as T;
                IsCreate = true;
            }
        }

        protected virtual void OnDestroy()
        {
            sInstance = null;
            IsCreate = false;
        }

        private void OnApplicationQuit()
        {
            sInstance = null;
            IsCreate = false;
        }

        public static void CreateInstance()
        {
            if (IsCreate == true)
                return;

            IsCreate = true;
            T[] managers = GameObject.FindObjectsOfType(typeof(T)) as T[];
            if (managers.Length != 0)
            {
                if (managers.Length == 1)
                {
                    sInstance = managers[0];
                    sInstance.gameObject.name = typeof(T).Name;
                    DontDestroyOnLoad(sInstance.gameObject);
                    return;
                }
                else
                {
                    foreach (T manager in managers)
                    {
                        Destroy(manager.gameObject);
                    }
                }
            }

            GameObject gO = new GameObject(typeof(T).Name, typeof(T));
            sInstance = gO.GetComponent<T>();
            DontDestroyOnLoad(sInstance.gameObject);
        }

        public static void ReleaseInstance()
        {
            if (sInstance != null)
            {
                Destroy(sInstance.gameObject);
                sInstance = null;
                IsCreate = false;
            }
        }
    }
 