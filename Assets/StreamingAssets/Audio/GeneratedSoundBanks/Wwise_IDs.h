/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID BUY = 714721615U;
        static const AkUniqueID CARD_THROW = 1110212438U;
        static const AkUniqueID DEFEAT = 1593864692U;
        static const AkUniqueID ENEMY_HIT = 1010055213U;
        static const AkUniqueID GUN_FIRE = 2517641552U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID PICKUP_COIN = 2682123183U;
        static const AkUniqueID PLAY_CRYSTAL = 2035174344U;
        static const AkUniqueID PLAY_DASH = 2211787386U;
        static const AkUniqueID PLAY_FIREBALL = 146533081U;
        static const AkUniqueID PLAY_HEAL = 2639148008U;
        static const AkUniqueID PLAY_LIGHTING = 293750690U;
        static const AkUniqueID PLAY_SHIELD = 1988178265U;
        static const AkUniqueID PLAY_SHOTGUN = 992244U;
        static const AkUniqueID PLAYER_STEP = 3461836331U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace PLAYERALIVE
        {
            static const AkUniqueID GROUP = 2557321869U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace PLAYERALIVE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace CARD_TYPE
        {
            static const AkUniqueID GROUP = 397198742U;

            namespace SWITCH
            {
                static const AkUniqueID CRYSTAL = 3444057113U;
                static const AkUniqueID DASH = 1942692385U;
                static const AkUniqueID FIREBALL = 3841200954U;
                static const AkUniqueID HEAL = 3448274447U;
                static const AkUniqueID LIGHTING = 3664531709U;
                static const AkUniqueID SHIELD = 1161967626U;
                static const AkUniqueID SHOTGUN = 51683977U;
            } // namespace SWITCH
        } // namespace CARD_TYPE

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
