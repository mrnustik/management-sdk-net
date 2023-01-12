﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using Kontent.Ai.Management.Models.Shared;
using Kontent.Ai.Management.Models.PreviewConfiguration;
using Kontent.Ai.Management.Tests.Base;
using Xunit;

namespace Kontent.Ai.Management.Tests.ManagementClientTests;

public class PreviewConfigurationTests : IClassFixture<FileSystemFixture>
{
    private readonly FileSystemFixture _fileSystemFixture;

    public PreviewConfigurationTests(FileSystemFixture fileSystemFixture)
    {
        _fileSystemFixture = fileSystemFixture;
        _fileSystemFixture.SetSubFolder("PreviewConfiguration");
    }

    [Fact]
    public async void GetPreviewConfigurations_GetsPreviewConfiguration()
    {
        var client = _fileSystemFixture.CreateMockClientWithResponse("PreviewConfiguration.json");
        var response = await client.GetPreviewConfigurationAsync();

        var expected = _fileSystemFixture.GetExpectedResponse<PreviewConfigurationResponseModel>("PreviewConfiguration.json");

        response.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public async void UpdatePreviewConfiguration_UpdatesPreviewConfiguration()
    {
        var newPreviewConfiguration = new PreviewConfigurationRequestModel
        {
           SpaceDomains = new List<SpaceDomainRequestModel> {
               new() {
                   Domain = "www.mysite.com",
                   Space = Reference.ByCodename("my_space")
               }
           },
           PreviewUrlPatterns = new List<TypePreviewUrlPatternRequestModel> {
               new() {
                   ContentType = Reference.ByCodename("article"),
                   UrlPatterns = new List<PreviewUrlPatternRequestModel> {
                       new() {
                           Enabled = true,
                           Space = null,
                           UrlPattern = "https://www.globalsite.com/{URLSlug}"
                       },
                       new() {
                           Enabled = true,
                           Space = Reference.ByCodename("my_space"),
                           UrlPattern = "https://{Space}/{URLSlug}/test"
                       },

                   }
               }
           }

        };

        var client = _fileSystemFixture.CreateMockClientWithResponse("PreviewConfiguration.json");
        var response = await client.UpdatePreviewConfigurationAsync(newPreviewConfiguration);
        var expected = _fileSystemFixture.GetExpectedResponse<PreviewConfigurationResponseModel>("PreviewConfiguration.json");

        response.Should().BeEquivalentTo(expected);
    }
    
}