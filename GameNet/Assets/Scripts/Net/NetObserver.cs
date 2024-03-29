﻿using com.sporger.server.proto.model;

namespace Stars
{
    public class NetObserver
    {
        public static void addObservers(Net net)
        {
            Game game = Game.Get();
            game.RegisterCommand(MessageType.LOGIN_VALIDATE.ToString(), () => new login_validate_handle());
            game.RegisterCommand(MessageType.LOGIN_VALIDATE_RECONNECT.ToString(), () => new login_validate_reconnect_handle());
            game.RegisterCommand(MessageType.NOTIFY_BE_KICKED_OFF.ToString(), () => new notify_be_kicked_off_handle());
            game.RegisterCommand(MessageType.CHARACTER_ATTRIBUTE.ToString(), () => new character_attribute_handle());
            game.RegisterCommand(MessageType.REQ_WEAR_EQUIP.ToString(), () => new req_wear_equip_handle());
            game.RegisterCommand(MessageType.REQ_UNINSTALL_EQUIP.ToString(), () => new req_uninstall_equip_handle());
            game.RegisterCommand(MessageType.NOTIFY_CHARACTER_CURRENCY.ToString(), () => new notify_character_currency_handle());
            game.RegisterCommand(MessageType.NOTIFY_CHARACTER_LEVEL_UP.ToString(), () => new notify_character_level_up_handle());
            game.RegisterCommand(MessageType.REQ_EQUIP_ATTRS.ToString(), () => new req_equip_attrs_handle());
            game.RegisterCommand(MessageType.REQ_SELL_ITME.ToString(), () => new req_sell_itme_handle());
            game.RegisterCommand(MessageType.REQ_USE_ITEM.ToString(), () => new req_use_item_handle());
            game.RegisterCommand(MessageType.REQ_EQUIP_START_UP.ToString(), () => new req_equip_start_up_handle());
            game.RegisterCommand(MessageType.REQ_DRAW_REWARD.ToString(), () => new req_draw_reward_handle());
            game.RegisterCommand(MessageType.REQ_DAILY_MISSION_LIST.ToString(), () => new req_daily_mission_list_handle());
            game.RegisterCommand(MessageType.REQ_DAILY_MISSION_REWARD.ToString(), () => new req_daily_mission_reward_handle());
            game.RegisterCommand(MessageType.REQ_TUTORIAL_INFO.ToString(), () => new req_tutorial_info_handle());
            game.RegisterCommand(MessageType.REQ_SAVE_TUTORIAL.ToString(), () => new req_save_tutorial_handle());
            game.RegisterCommand(MessageType.REQ_SAVE_TRIGGER_TUTORIAL.ToString(), () => new req_save_trigger_tutorial_handle());
            game.RegisterCommand(MessageType.REQ_SAVE_CAREER_PLOT.ToString(), () => new req_save_career_plot_handle());
            game.RegisterCommand(MessageType.REQ_PLAYER_FRIENDS.ToString(), () => new req_player_friends_handle());
            game.RegisterCommand(MessageType.REQ_FRIEND_STATE.ToString(), () => new req_friend_state_handle());
            game.RegisterCommand(MessageType.REQ_FRIEND_DETAILED.ToString(), () => new req_friend_detailed_handle());
            game.RegisterCommand(MessageType.REQ_ATTENTION_PLAYER.ToString(), () => new req_attention_player_handle());
            game.RegisterCommand(MessageType.NOTIFY_PLAYER_ATTENTION.ToString(), () => new notify_player_attention_handle());
            game.RegisterCommand(MessageType.REQ_JOIN_GAME.ToString(), () => new req_join_game_handle());
            game.RegisterCommand(MessageType.REQ_VISIT_GAME.ToString(), () => new req_visit_game_handle());
            game.RegisterCommand(MessageType.REQ_FRIEND_MESSAGE.ToString(), () => new req_friend_message_handle());
            game.RegisterCommand(MessageType.REQ_DELECT_FRIEND_MESSAGE.ToString(), () => new req_delect_friend_message_handle());
            game.RegisterCommand(MessageType.REQ_FRIENDS_RELATION.ToString(), () => new req_friends_relation_handle());
            game.RegisterCommand(MessageType.REQ_SEARCH_PLAYER.ToString(), () => new req_search_player_handle());
            game.RegisterCommand(MessageType.REQ_PLAYER_BASE_INFO.ToString(), () => new req_player_base_info_handle());
            game.RegisterCommand(MessageType.REQ_ENTER_MAP.ToString(), () => new req_enter_map_handle());
            game.RegisterCommand(MessageType.ENTER_MAP.ToString(), () => new enter_map_handle());
            game.RegisterCommand(MessageType.PLAYER_GOIN_INSTANCE.ToString(), () => new player_goin_instance_handle());
            game.RegisterCommand(MessageType.PLAYER_EXIT_INSTANCE.ToString(), () => new player_exit_instance_handle());
            game.RegisterCommand(MessageType.SYNC_PLAYER_INSTANCE_POS.ToString(), () => new sync_player_instance_pos_handle());
            game.RegisterCommand(MessageType.REQ_SERVER_TIME.ToString(), () => new req_server_time_handle());
            game.RegisterCommand(MessageType.HEARTBEAT.ToString(), () => new heartbeat_handle());
            game.RegisterCommand(MessageType.REQ_MATCHING.ToString(), () => new req_matching_handle());
            game.RegisterCommand(MessageType.REQ_CANCEL_MATCHING.ToString(), () => new req_cancel_matching_handle());
            game.RegisterCommand(MessageType.NOTIFY_MATCHING_RESULT.ToString(), () => new notify_matching_result_handle());
            game.RegisterCommand(MessageType.REQ_ENTER_PRE_SCENE.ToString(), () => new req_enter_pre_scene_handle());
            game.RegisterCommand(MessageType.NOTIFY_PLAYER_READY_ENTER_PRE_SCENE.ToString(), () => new notify_player_ready_enter_pre_scene_handle());
            game.RegisterCommand(MessageType.NOTIFY_PERMITE_ENTER_PRE_SCENE.ToString(), () => new notify_permite_enter_pre_scene_handle());
            game.RegisterCommand(MessageType.REQ_SELECT_SCENE.ToString(), () => new req_select_scene_handle());
            game.RegisterCommand(MessageType.NOTIFY_CHANGE_SCENE.ToString(), () => new notify_change_scene_handle());
            game.RegisterCommand(MessageType.REQ_READY.ToString(), () => new req_ready_handle());
            game.RegisterCommand(MessageType.NOTIFY_READY.ToString(), () => new notify_ready_handle());
            game.RegisterCommand(MessageType.NOTIFY_CHANGE_ROOM_OWNER.ToString(), () => new notify_change_room_owner_handle());
            game.RegisterCommand(MessageType.NOTIFY_START_RACE.ToString(), () => new notify_start_race_handle());
            game.RegisterCommand(MessageType.NOTIFY_CAREER_RUN_END.ToString(), () => new notify_career_run_end_handle());
            game.RegisterCommand(MessageType.REQ_FREE_RUN_END.ToString(), () => new req_free_run_end_handle());
            game.RegisterCommand(MessageType.NOTIFY_PLAYER_REACH.ToString(), () => new notify_player_reach_handle());
            game.RegisterCommand(MessageType.NOTIFY_OUTDOOR_PVP_RESULT.ToString(), () => new notify_outdoor_pvp_result_handle());
            game.RegisterCommand(MessageType.NOTIFY_ITEM_PVP_RESULT.ToString(), () => new notify_item_pvp_result_handle());
            game.RegisterCommand(MessageType.REQ_PLAYER_LIST.ToString(), () => new req_player_list_handle());
            game.RegisterCommand(MessageType.REQ_NEW_PLAYER_LIST_SIMPLE_INFO.ToString(), () => new req_new_player_list_simple_info_handle());
            game.RegisterCommand(MessageType.NOTIFY_CONFIRM_MATCHING_TIME_OUT.ToString(), () => new notify_confirm_matching_time_out_handle());
            game.RegisterCommand(MessageType.NOTIFY_LEVEL_STAR_END.ToString(), () => new notify_level_star_end_handle());
            game.RegisterCommand(MessageType.REQ_ENTER_CAREER_MAP.ToString(), () => new req_enter_career_map_handle());
            game.RegisterCommand(MessageType.REQ_REALTIME_VOICE.ToString(), () => new req_realtime_voice_handle());
            game.RegisterCommand(MessageType.REQ_CANCEL_REALTIME_VOICE.ToString(), () => new req_cancel_realtime_voice_handle());
            game.RegisterCommand(MessageType.REQ_ACCEPT_REALTIME_VOICE.ToString(), () => new req_accept_realtime_voice_handle());
            game.RegisterCommand(MessageType.REQ_HANGUP_REALTIME_VOICE.ToString(), () => new req_hangup_realtime_voice_handle());
            game.RegisterCommand(MessageType.NOTIFY_REALTIME_VOICE_REQ.ToString(), () => new notify_realtime_voice_req_handle());
            game.RegisterCommand(MessageType.NOTIFY_REALTIME_VOICE_REQ_FAILURE.ToString(), () => new notify_realtime_voice_req_failure_handle());
            game.RegisterCommand(MessageType.NOTIFY_PLAYER_JOIN_REALTIME_VOICE_ROOM.ToString(), () => new notify_player_join_realtime_voice_room_handle());
            game.RegisterCommand(MessageType.NOTIFY_CANCEL_REALTIME_VOICE_REQ.ToString(), () => new notify_cancel_realtime_voice_req_handle());
            game.RegisterCommand(MessageType.NOTIFY_PLAYER_LEAVE_REALTIME_VOICE_ROOM.ToString(), () => new notify_player_leave_realtime_voice_room_handle());
            game.RegisterCommand(MessageType.REQ_ENTER_FAM.ToString(), () => new req_enter_fam_handle());
            game.RegisterCommand(MessageType.REQ_ENTER_FAM_MAP.ToString(), () => new req_enter_fam_map_handle());
            game.RegisterCommand(MessageType.REQ_OPEN_TREASURE_BOX.ToString(), () => new req_open_treasure_box_handle());
            game.RegisterCommand(MessageType.NOTIFY_BOX_AND_ITEM_LIST.ToString(), () => new notify_box_and_item_list_handle());
            game.RegisterCommand(MessageType.NOTIFY_OPEN_TREASURE_BOX.ToString(), () => new notify_open_treasure_box_handle());
            game.RegisterCommand(MessageType.REQ_PICK_OPEN_TREASURE_BOX_ITEM.ToString(), () => new req_pick_open_treasure_box_item_handle());
            game.RegisterCommand(MessageType.NOTIFY_PICK_OPEN_TREASURE_ITEM.ToString(), () => new notify_pick_open_treasure_item_handle());
            game.RegisterCommand(MessageType.REQ_DISCARD_OPEN_TREASURE_BOX_ITEM.ToString(), () => new req_discard_open_treasure_box_item_handle());
            game.RegisterCommand(MessageType.NOTIFY_SPAWN_ORDINARY_BOX.ToString(), () => new notify_spawn_ordinary_box_handle());
            game.RegisterCommand(MessageType.NOTIFY_SPAWN_ITEM_AND_BOX.ToString(), () => new notify_spawn_item_and_box_handle());
            game.RegisterCommand(MessageType.NOTIFY_SPAWN_MP_ORDINARY_BOX.ToString(), () => new notify_spawn_mp_ordinary_box_handle());
            game.RegisterCommand(MessageType.NOTIFY_OPEN_MP_ORDINARY_BOX_STAND_POS.ToString(), () => new notify_open_mp_ordinary_box_stand_pos_handle());
            game.RegisterCommand(MessageType.NOTIFY_RESTORE_MP_ORDINARY_BOX_STAND_POS.ToString(), () => new notify_restore_mp_ordinary_box_stand_pos_handle());
            game.RegisterCommand(MessageType.NOTIFY_ACTIVITY_END.ToString(), () => new notify_activity_end_handle());
            game.RegisterCommand(MessageType.REQ_MAZE_MATCHING.ToString(), () => new req_maze_matching_handle());
            game.RegisterCommand(MessageType.NOTIFY_MAZE_MATCHING_RESULT.ToString(), () => new notify_maze_matching_result_handle());
            game.RegisterCommand(MessageType.REQ_MAZE_CANCEL_MATCHING.ToString(), () => new req_maze_cancel_matching_handle());
            game.RegisterCommand(MessageType.NOTIFY_MAZE_WAIT_COUNT_DOWN.ToString(), () => new notify_maze_wait_count_down_handle());
            game.RegisterCommand(MessageType.NOTIFY_MAZE_START_GAME_COUNT_DOWN.ToString(), () => new notify_maze_start_game_count_down_handle());
            game.RegisterCommand(MessageType.NOTIFY_MAZE_START_GAME.ToString(), () => new notify_maze_start_game_handle());
            game.RegisterCommand(MessageType.NOTIFY_MAZE_PLAYER_NOT_ENOUGH.ToString(), () => new notify_maze_player_not_enough_handle());
            game.RegisterCommand(MessageType.REQ_MAZE_DESTROY_DOOR.ToString(), () => new req_maze_destroy_door_handle());
            game.RegisterCommand(MessageType.NOTIFY_MAZE_DESTROY_DOOR.ToString(), () => new notify_maze_destroy_door_handle());
            game.RegisterCommand(MessageType.NOTIFY_MAZE_SPAWN_DOOR.ToString(), () => new notify_maze_spawn_door_handle());
            game.RegisterCommand(MessageType.REQ_ENTER_FINISH_POINT.ToString(), () => new req_enter_finish_point_handle());
            game.RegisterCommand(MessageType.NOTIFY_FINISH_MAZE_GAME.ToString(), () => new notify_finish_maze_game_handle());
            game.RegisterCommand(MessageType.NOTIFY_MAZE_CHARACTER_ENERGE.ToString(), () => new notify_maze_character_energe_handle());
            game.RegisterCommand(MessageType.REQ_MAZE_PICK_ENERGE_ITEM.ToString(), () => new req_maze_pick_energe_item_handle());
            game.RegisterCommand(MessageType.NOTIFY_MAZE_SPAWN_ENERGE_ITEM.ToString(), () => new notify_maze_spawn_energe_item_handle());
            game.RegisterCommand(MessageType.NOTIFY_MAZE_PICK_ENERGE_ITEM.ToString(), () => new notify_maze_pick_energe_item_handle());
            game.RegisterCommand(MessageType.NOTIFY_WATCH_RACE_FINISHED.ToString(), () => new notify_watch_race_finished_handle());
            game.RegisterCommand(MessageType.REQ_ENTER_SQUARE.ToString(), () => new req_enter_square_handle());
            game.RegisterCommand(MessageType.REQ_HOT_SQUARE_CHAT_GROUP.ToString(), () => new req_hot_square_chat_group_handle());
            game.RegisterCommand(MessageType.REQ_CREATE_SQUARE_CHAT_GROUP.ToString(), () => new req_create_square_chat_group_handle());
            game.RegisterCommand(MessageType.NOTIFY_ADVERTISEMENT.ToString(), () => new notify_advertisement_handle());
            game.RegisterCommand(MessageType.REQ_ENTER_SQUARE_CHAT_GROUP.ToString(), () => new req_enter_square_chat_group_handle());
            game.RegisterCommand(MessageType.NOTIFY_ENTER_SQUARE_CHAT_GROUP.ToString(), () => new notify_enter_square_chat_group_handle());
            game.RegisterCommand(MessageType.REQ_SQUARE_CHAT_INFO.ToString(), () => new req_square_chat_info_handle());
            game.RegisterCommand(MessageType.NOTIFY_SQUARE_CHAT_INFO.ToString(), () => new notify_square_chat_info_handle());
            game.RegisterCommand(MessageType.REQ_CLOSE_SQUARE_CHAT_GROUP.ToString(), () => new req_close_square_chat_group_handle());
            game.RegisterCommand(MessageType.REQ_EXIT_SQUARE_CHAT_GROUP.ToString(), () => new req_exit_square_chat_group_handle());
            game.RegisterCommand(MessageType.NOTIFY_CLOSE_CHAT_GROUP.ToString(), () => new notify_close_chat_group_handle());
            game.RegisterCommand(MessageType.NOTIFY_EXIT_CHAT_GROUP.ToString(), () => new notify_exit_chat_group_handle());
            game.RegisterCommand(MessageType.REQ_SQUARE_INVITE_FRIEND.ToString(), () => new req_square_invite_friend_handle());
            game.RegisterCommand(MessageType.REQ_SQUARE_INVITE_AGREE_FRIEND.ToString(), () => new req_square_invite_agree_friend_handle());
            game.RegisterCommand(MessageType.REQ_RAINBOWRUN_MATCHING.ToString(), () => new req_rainbowrun_matching_handle());
            game.RegisterCommand(MessageType.NOTIFY_RAINBOWRUN_MATCHING_RESULT.ToString(), () => new notify_rainbowrun_matching_result_handle());
            game.RegisterCommand(MessageType.REQ_RAINBOWRUN_CANCEL_MATCHING.ToString(), () => new req_rainbowrun_cancel_matching_handle());
            game.RegisterCommand(MessageType.REQ_RAINBOWRUN_CHANGE_TRACK.ToString(), () => new req_rainbowrun_change_track_handle());
            game.RegisterCommand(MessageType.NOTIFY_RAINBOWRUN_CHANGE_TRACK.ToString(), () => new notify_rainbowrun_change_track_handle());
            game.RegisterCommand(MessageType.NOTIFY_RAINBOWRUN_CURRENT_INFO.ToString(), () => new notify_rainbowrun_current_info_handle());
            game.RegisterCommand(MessageType.NOTIFY_RAINBOWRUN_GAMEOVER.ToString(), () => new notify_rainbowrun_gameover_handle());
            game.RegisterCommand(MessageType.REQ_RAINBOWRUN_READY.ToString(), () => new req_rainbowrun_ready_handle());
            game.RegisterCommand(MessageType.NOTIFY_RAINBOWRUN_READY.ToString(), () => new notify_rainbowrun_ready_handle());
            game.RegisterCommand(MessageType.NOTIFY_RAINBOWRUN_LOAD_SCENE.ToString(), () => new notify_rainbowrun_load_scene_handle());
            game.RegisterCommand(MessageType.LOCATION.ToString(), () => new location_handle());
            game.RegisterCommand(MessageType.REQ_CHARACTER_STATUS.ToString(), () => new req_character_status_handle());
            game.RegisterCommand(MessageType.NOTIFY_CHARACTER_STATUS.ToString(), () => new notify_character_status_handle());
            game.RegisterCommand(MessageType.REQ_MAZE_CHARACTER_STATUS.ToString(), () => new req_maze_character_status_handle());
            game.RegisterCommand(MessageType.REQ_CITY_CHARACTER_STATUS.ToString(), () => new req_city_character_status_handle());
            game.RegisterCommand(MessageType.REQ_RAINBOW_RUN_CHARACTER_STATUS.ToString(), () => new req_rainbow_run_character_status_handle());
            game.RegisterCommand(MessageType.RUN_REPORT.ToString(), () => new run_report_handle());
            game.RegisterCommand(MessageType.REQ_RUN_BASE_INFO.ToString(), () => new req_run_base_info_handle());
            game.RegisterCommand(MessageType.REQ_PULL_RUN_RECORD.ToString(), () => new req_pull_run_record_handle());
            game.RegisterCommand(MessageType.REQ_RUN_BEST_RECORD_LIST.ToString(), () => new req_run_best_record_list_handle());
            game.RegisterCommand(MessageType.REQ_RUN_RECORD_DETAIL.ToString(), () => new req_run_record_detail_handle());
            game.RegisterCommand(MessageType.NOTIFY_SPORGER_CHANGE.ToString(), () => new notify_sporger_change_handle());
            game.RegisterCommand(MessageType.REQ_WARM_BODY_FINISH.ToString(), () => new req_warm_body_finish_handle());
            game.RegisterCommand(MessageType.NOTIFY_RUN_REPORT.ToString(), () => new notify_run_report_handle());
            game.RegisterCommand(MessageType.NOTIFY_GET_REWARD.ToString(), () => new notify_get_reward_handle());
            game.RegisterCommand(MessageType.NOTIFY_GM_LEVELUP.ToString(), () => new notify_gm_levelup_handle());
            game.RegisterCommand(MessageType.REQ_GM_COMMAND.ToString(), () => new req_gm_command_handle());
        }
    }
}
