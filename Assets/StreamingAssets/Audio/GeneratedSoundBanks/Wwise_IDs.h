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
        static const AkUniqueID STEP = 621108255U;
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
                static const AkUniqueID CLUB = 4072605221U;
                static const AkUniqueID DIAMOND = 2830210367U;
                static const AkUniqueID HEART = 2665378999U;
                static const AkUniqueID SPADE = 4148060796U;
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
