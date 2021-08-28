﻿using System;
using NUnit.Framework;

namespace FASTER.remote.test
{
    [TestFixture]
    public class VarLenBinaryPubSubTests
    {
        VarLenServer server;
        VarLenMemoryClient client;

        [SetUp]
        public void Setup()
        {
            server = new VarLenServer(TestContext.CurrentContext.TestDirectory + "/VarLenBinaryTests", enablePubSub: true);
            client = new VarLenMemoryClient();
        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
            server.Dispose();
        }

        [Test]
        public void SubscribeKVTest()
        {
            Random r = new Random(23);
            var session = client.GetSession();
            var subSession = client.GetSession();
            var key = new Memory<int>(new int[2 + r.Next(50)]);
            var value = new Memory<int>(new int[1 + r.Next(50)]);
            key.Span[0] = r.Next(100);
            key.Span[1] = value.Length;
            value.Span.Fill(key.Span[0]);

            subSession.SubscribeKV(key);
            subSession.CompletePending(true);
            session.Upsert(key, value);
            session.CompletePending(true);

            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void PSubscribeKVTest()
        {
            Random r = new Random(23);
            var session = client.GetSession();
            var subSession = client.GetSession();
            var key = new Memory<int>(new int[2 + r.Next(50)]);
            var value = new Memory<int>(new int[1 + r.Next(50)]);
            int randomNum = r.Next(100);
            key.Span[0] = randomNum;
            key.Span[1] = value.Length;
            value.Span.Fill(key.Span[0]);

            var upsertKey = new Memory<int>(new int[100]);
            upsertKey.Span[0] = randomNum;
            upsertKey.Span[1] = value.Length;

            subSession.PSubscribeKV(key);
            subSession.CompletePending(true);
            session.Upsert(upsertKey, value);
            session.CompletePending(true);

            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void SubscribeTest()
        {
            Random r = new Random(23);
            var session = client.GetSession();
            var subSession = client.GetSession();
            var key = new Memory<int>(new int[2 + r.Next(50)]);
            var value = new Memory<int>(new int[1 + r.Next(50)]);
            key.Span[0] = r.Next(100);
            key.Span[1] = value.Length;
            value.Span.Fill(key.Span[0]);

            subSession.SubscribeKV(key);
            subSession.CompletePending(true);
            session.Upsert(key, value);
            session.CompletePending(true);

            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void PSubscribeTest()
        {
            Random r = new Random(23);
            var session = client.GetSession();
            var subSession = client.GetSession();
            var key = new Memory<int>(new int[2 + r.Next(50)]);
            var value = new Memory<int>(new int[1 + r.Next(50)]);
            int randomNum = r.Next(100);
            key.Span[0] = randomNum;
            key.Span[1] = value.Length;
            value.Span.Fill(key.Span[0]);

            var upsertKey = new Memory<int>(new int[100]);
            upsertKey.Span[0] = randomNum;
            upsertKey.Span[1] = value.Length;

            subSession.PSubscribeKV(key);
            subSession.CompletePending(true);
            session.Upsert(upsertKey, value);
            session.CompletePending(true);

            System.Threading.Thread.Sleep(1000);
        }
    }
}