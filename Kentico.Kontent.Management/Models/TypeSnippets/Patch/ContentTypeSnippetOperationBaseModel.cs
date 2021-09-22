﻿using Newtonsoft.Json;

namespace Kentico.Kontent.Management.Models.TypeSnippets.Patch
{
    /// <summary>
    /// Represents the operation on the content type snippet.
    /// More info: https://docs.kontent.ai/reference/management-api-v2#operation/modify-a-content-type-snippet
    /// </summary>
    public abstract class ContentTypeSnippetOperationBaseModel
    {
        /// <summary>
        /// Gets specification of the operation to perform.
        /// More info: https://docs.kontent.ai/reference/management-api-v2#operation/modify-a-content-type-snippet
        /// </summary>
        [JsonProperty("op", Required = Required.Always)]
        public abstract string Op { get; }

        /// <summary>
        /// Gets or sets a string identifying where the new object or property should be added/replaced/removed.
        /// More info: https://docs.kontent.ai/reference/management-api-v2#operation/modify-a-content-type
        /// </summary>
        [JsonProperty("path", Required = Required.Always)]
        public string Path { get; set; }
    }
}
