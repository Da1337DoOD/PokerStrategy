using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PokerStrategy.Web.Tests
{
    public class PagesTests
    {
        [Fact]
        public async Task HomePageShouldContainImgTag()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<img", responseAsString);
        }

        [Fact]
        public async Task HomePageShouldContainHeader()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<header", responseAsString);
        }

        [Fact]
        public async Task NewsAllShouldContainBody()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/News/All");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<body", responseAsString);
        }

        [Fact]
        public async Task VideoAllShouldContainBody()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/Video/All");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<body", responseAsString);
        }

        [Fact]
        public async Task ForumShouldContainTable()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/Forum");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<table", responseAsString);
        }

        [Fact]
        public async Task VideoShouldContainTable()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/Video/Video/1");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<div", responseAsString);
        }

        [Fact]
        public async Task NewsShouldContainTable()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var httpClient = serverFactory.CreateClient();

            var response = await httpClient.GetAsync("/News/News/1");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<div", responseAsString);
        }
    }
}
