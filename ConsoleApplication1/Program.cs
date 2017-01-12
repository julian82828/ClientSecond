using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using ProCSharp.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Lifetime;
using RemoteHello;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApplication1
{
    class Program
    {
        public delegate  string GreetingDelegate(string name);
        private static string greeting;

        static void Main(string[] args)
        {
            //ChannelServices.RegisterChannel(ne1212w TsdfdsfcpClientChannel(), false);
            ////使用GetObject创asdsad建代理对象
            //object tcpClient = Activator.GetObject(typeof(Hello), "tcp://localhost:8086/Hi");

            ////或则这样使用connect创建代理对象
            //object tctClient2 = RemotingServices.Connect(typeof(Hello), "tcp://localhost:8086/Hi");

            //if (tcpClient == null)
            //{
            //    Console.WriteLine("Can not link to server");
            //}
            //else
            //{
            //    Hello temp = tcpClient as Hello;
            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.WriteLine(temp.Greeting("julian"));
            //        Console.WriteLine("please any key to return");
            //        Console.ReadLine();
            //    }

            //}

            ////使用new运算符激活知名的远程对象
            //RemotingConfiguration.RegisterWellKnownClientType(typeof(Hello), "tcp://localhost:8086/Hi");
            //Hello obj = new Hello();

            //激活知名对象，方法：Activator.GetObject
            //ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            //Hello objHello = (Hello)Activator.GetObject(typeof(Hello), "tcp://localhost:8086/Hi");
            //if (objHello == null)
            //{
            //    Console.WriteLine("Can not link to Server");
            //}
            //else
            //{

            ////以下为实际对象，串行化到客户断的
            //MySerialized mySer = objHello.GetMySerialized();

            //if (!RemotingServices.IsTransparentProxy(mySer))
            //{
            //    Console.WriteLine("MySerialized is not a Proxy");
            //}

            //mySer.foo();

            ////以下为透明代理对象，超出了应用程序域
            //MyRemoted myRem = objHello.GetMyRemoted();
            //if (RemotingServices.IsTransparentProxy(myRem))
            //{
            //    Console.WriteLine("MyRemoted is a proxy");
            //}
            //myRem.foo();

            //Console.WriteLine("Please enter any key to return!");
            //Console.ReadLine();
            //}

            ////客户端 调用客户激活的对象
            //ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            //object[] attrs = { new UrlAttribute("tcp://localhost:8086/Hello") };
            //Hello objtem = (Hello)Activator.CreateInstance(typeof(Hello), null, attrs);

            ////访问租约信息
            //ILease lease = objtem.GetLifetimeService() as ILease;

            //通过配置文件，创建代理对象
            //RemotingConfiguration.Configure(@"..\ConsoleApplication1\ConsoleApplication1.exe.config", false);
            //Hello obj = new Hello();
            //if (obj == null)
            //{
            //    Console.WriteLine("Could not link to server");
            //    return;
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(obj.Greeting("julian"));
            //}
            //Console.ReadLine();

            //使用委托异步调用代理对象的方法
            //RemotingConfiguration.Configure(@"..\ConsoleApplication1\ConsoleApplication1.exe.config", false);
            //Hello obj = new Hello();
            //if (obj == null)
            //{
            //    Console.WriteLine("Could not locate server");
            //    return;
            //}
            //GreetingDelegate d = new GreetingDelegate(obj.Greeting);
            //IAsyncResult ar = d.BeginInvoke("Julian", null, null);

            //ar.AsyncWaitHandle.WaitOne();
            //if (ar.IsCompleted)
            //{
            //    greeting = d.EndInvoke(ar);
            //}
            //Console.WriteLine(greeting);

            //RemotingConfiguration.Configure(@"..\ConsoleApplication1\ConsoleApplication1.exe.config", false);
            //Hello obj = new Hello();
            //if (obj == null)
            //{
            //    Console.WriteLine("Could not locate server");
            //    return;
            //}
            //obj.TakeAWhile(5000);

            //Console.ReadLine();

            ////区分按值编组的对象  和按引用编组的对象
            //RemotingConfiguration.Configure(@"..\ConsoleApplication1\ConsoleApplication1.exe.config", false);
            //Hello objHello = new Hello();

            ////以下为实际对象，串行化到客户断的
            //MySerialized mySer = objHello.GetMySerialized();

            //if (!RemotingServices.IsTransparentProxy(mySer))
            //{
            //    Console.WriteLine("MySerialized is not a Proxy");
            //}

            //mySer.foo();

            ////以下为透明代理对象，超出了应用程序域
            //MyRemoted myRem = objHello.GetMyRemoted();
            //if (RemotingServices.IsTransparentProxy(myRem))
            //{
            //    Console.WriteLine("MyRemoted is a proxy");
            //}
            //myRem.foo();

            //Console.WriteLine("Please enter any key to return!");
            //Console.ReadLine();

            //使用 调用环境 获取客户发送的数据
            RemotingConfiguration.Configure(@"..\ConsoleApplication1\ConsoleApplication1.exe.config", false);
            Hello obj = new Hello();

            CallContextData cookie = new CallContextData();
            cookie.Data = "information for the server";
            CallContext.SetData("mycookie", cookie);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(obj.Greeting("Julian", "01"));
            }
            Console.ReadLine();
        }
    }
}
