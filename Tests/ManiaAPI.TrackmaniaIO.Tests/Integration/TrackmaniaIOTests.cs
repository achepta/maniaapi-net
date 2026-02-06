using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ManiaAPI.TrackmaniaIO.Tests.Integration;

public class TrackmaniaIOTests(ITestOutputHelper output)
{
    [Fact]
    public async Task TestVariousRequests()
    {
        var trackmaniaIO = new TrackmaniaIO("ManiaAPI.TrackmaniaIO Integration Test 1.0 (Discord=bigbang1112)");

        var seasonalCampaigns = await trackmaniaIO.GetSeasonalCampaignsAsync();
        var clubCampaigns = await trackmaniaIO.GetClubCampaignsAsync();
        var weeklyShortCampaigns = await trackmaniaIO.GetWeeklyShortCampaignsAsync();
        var weeklyGrandCampaigns = await trackmaniaIO.GetWeeklyGrandCampaignsAsync();
        var seasonalCampaign = await trackmaniaIO.GetSeasonalCampaignAsync(campaignId: seasonalCampaigns.Campaigns.First().Id);
        var clubs = await trackmaniaIO.GetClubsAsync();
        var club = await trackmaniaIO.GetClubAsync(clubId: clubs.Clubs.First().Id);
        var clubMembers = await trackmaniaIO.GetClubMembersAsync(club.Id);
        var clubActivities = await trackmaniaIO.GetClubActivitiesAsync(club.Id);
        var clubCampaign = await trackmaniaIO.GetClubCampaignAsync(clubCampaigns.Campaigns.First().ClubId.GetValueOrDefault(), clubCampaigns.Campaigns.First().Id);
        var weekShortCampaign = await trackmaniaIO.GetWeeklyShortCampaignAsync(weeklyShortCampaigns.Campaigns.First().Id);
        var weekGrandCampaign = await trackmaniaIO.GetWeeklyGrandCampaignAsync(weeklyGrandCampaigns.Campaigns.First().Id);
        var leaderboardByLeaderboardUid = await trackmaniaIO.GetLeaderboardAsync(seasonalCampaign.LeaderboardUid, seasonalCampaign.Playlist.First().MapUid);
        var leaderboard = await trackmaniaIO.GetLeaderboardAsync(seasonalCampaign.Playlist.First().MapUid);
        var recentWorldRecords = await trackmaniaIO.GetRecentWorldRecordsAsync(seasonalCampaign.LeaderboardUid);
        var mapInfo = await trackmaniaIO.GetMapInfoAsync(seasonalCampaign.Playlist.First().MapUid);
        var clubRooms = await trackmaniaIO.GetClubRoomsAsync();
        var clubRoom = await trackmaniaIO.GetClubRoomAsync(clubRooms.Rooms.First().ClubId, clubRooms.Rooms.First().Id);
        var competitions = await trackmaniaIO.GetCompetitionsAsync();
        var competition = await trackmaniaIO.GetCompetitionAsync(competitions.Competitions.First().CompetitionId);
        var totds = await trackmaniaIO.GetTrackOfTheDaysAsync();
        var ads = await trackmaniaIO.GetAdsAsync();
    }
}
