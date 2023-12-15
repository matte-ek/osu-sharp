﻿using Newtonsoft.Json;
using OsuSharp.Enums;
using OsuSharp.Models;
using OsuSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OsuSharp;

// https://osu.ppy.sh/docs/index.html#beatmaps

public partial class OsuApiClient
{
  /// <summary>
  /// Looksup the beatmap with the specified MD5 checksum from the osu! API v2.
  /// If the beatmap is not found, null is returned.
  /// 
  /// https://osu.ppy.sh/docs/index.html#lookup-beatmap
  /// </summary>
  /// <param name="checksum">The MD5 checksum of the beatmap.</param>
  /// <returns>The beatmap.</returns>
  public async Task<Beatmap?> LookupBeatmapChecksum(string checksum) => await LookupBeatmapInternal($"checksum={HttpUtility.UrlEncode(checksum)}");

  /// <summary>
  /// Looksup the beatmap with the specified filename from the osu! API v2.
  /// 
  /// https://osu.ppy.sh/docs/index.html#lookup-beatmap
  /// </summary>
  /// <param name="checksum">The filename of the beatmap.</param>
  /// <returns>The beatmap.</returns>
  public async Task<Beatmap?> LookupBeatmapFilename(string filename) => await LookupBeatmapInternal($"filename={HttpUtility.UrlEncode(filename)}");

  /// <summary>
  /// Looksup the beatmap with the specified ID from the osu! API v2.
  /// 
  /// https://osu.ppy.sh/docs/index.html#lookup-beatmap
  /// </summary>
  /// <param name="beatmapId">The beatmap ID.</param>
  /// <returns>The beatmap.</returns>
  public async Task<Beatmap?> LookupBeatmapId(int beatmapId) => await LookupBeatmapInternal($"id={beatmapId}");

  /// <summary>
  /// Looksup the beatmap with the specified query parameter from the osu! API v2.
  /// 
  /// https://osu.ppy.sh/docs/index.html#lookup-beatmap
  /// </summary>
  /// <param name="param">The query parameter.</param>
  /// <returns>The beatmap.</returns>
  private async Task<Beatmap?> LookupBeatmapInternal(string param)
  {
    // Send the request and return the beatmap object.
    return await GetFromJsonAsync<Beatmap>($"beatmaps/lookup?{param}");
  }

  public async Task<object> GetUserBeatmapScore(int beatmapId, int userId, Ruleset? ruleset = null, string? mods = null)
  {

  }

  /// <summary>
  /// Gets the beatmap with the specified ID from the osu! API v2.
  /// 
  /// https://osu.ppy.sh/docs/index.html#get-beatmap
  /// </summary>
  /// <param name="id">The ID of the beatmap.</param>
  /// <returns>The beatmap.</returns>
  public async Task<Beatmap?> GetBeatmap(int id)
  {
    // Send the request and return the beatmap object.
    return await GetFromJsonAsync<Beatmap>($"beatmaps/{id}");
  }
}