const _0x4e5f08=_0x56d8;(function(_0x46c522,_0x2c91d0){const _0x50a76d=_0x56d8,_0x3ac964=_0x46c522();while(!![]){try{const _0x3bcaba=-parseInt(_0x50a76d(0x215))/0x1+parseInt(_0x50a76d(0x230))/0x2*(parseInt(_0x50a76d(0x1e2))/0x3)+-parseInt(_0x50a76d(0x1c1))/0x4*(parseInt(_0x50a76d(0x1c9))/0x5)+parseInt(_0x50a76d(0x1cd))/0x6+parseInt(_0x50a76d(0x1a8))/0x7*(-parseInt(_0x50a76d(0x24b))/0x8)+parseInt(_0x50a76d(0x23c))/0x9+-parseInt(_0x50a76d(0x244))/0xa*(-parseInt(_0x50a76d(0x216))/0xb);if(_0x3bcaba===_0x2c91d0)break;else _0x3ac964['push'](_0x3ac964['shift']());}catch(_0x5481d0){_0x3ac964['push'](_0x3ac964['shift']());}}}(_0x579c,0x1b8c8));const SDK_VERSION=_0x4e5f08(0x1b8),HisPlayerStatus={'HISPLAYER_STATUS_NONE':0x0,'HISPLAYER_STATUS_CLOSE':0x1,'HISPLAYER_STATUS_STOP':0x2,'HISPLAYER_STATUS_PLAY':0x3,'HISPLAYER_STATUS_PAUSE':0x4},HP_CONTENT_INFO_INDEX={'MEDIA_TYPE':0x0,'MEDIA_DURATION':0x1,'VIDEO_CODEC':0x2,'VIDEO_WIDTH':0x3,'VIDEO_HEIGHT':0x4,'VIDEO_CODEC_RENDER_TIME':0x3f1},HisPlayerEvent={'HISPLAYER_EVENT_PLAYBACK_READY':0x0,'HISPLAYER_EVENT_VIDEO_SIZE_CHANGE':0x2,'HISPLAYER_EVENT_PLAYBACK_PLAY':0x3,'HISPLAYER_EVENT_PLAYBACK_PAUSE':0x4,'HISPLAYER_EVENT_PLAYBACK_STOP':0x5,'HISPLAYER_EVENT_PLAYBACK_SEEK':0x6,'HISPLAYER_EVENT_END_OF_CONTENT':0x14,'HISPLAYER_EVENT_ON_TIME':0x15},HisPlayerError={'HISPLAYER_ERROR_GENERAL_LICENSE_ERROR':0x2,'HISPLAYER_ERROR_IMPRESSIONS_LIMIT_REACHED':0xc};class MultipleView{['multiStreamPlayerStatus']=[];['controlInstance']=0x0;[_0x4e5f08(0x1ef)];['playerIds']=[];['playerDivs']=[];[_0x4e5f08(0x1c4)]=![];#logger;#autoplay;#started=[];constructor(){const _0x2aa9bd=_0x4e5f08;this[_0x2aa9bd(0x1ef)]=new hisplayer['MultiView'](),this.#logger=Logger[_0x2aa9bd(0x21f)]();}[_0x4e5f08(0x22c)](_0x193337,_0x2890cc){const _0x1496f4=_0x4e5f08;this[_0x1496f4(0x212)][_0x2890cc]=HisPlayerStatus['HISPLAYER_STATUS_NONE'];const _0x207bbd=this;this[_0x1496f4(0x1ef)][_0x1496f4(0x1d2)](this[_0x1496f4(0x1ef)][_0x1496f4(0x1bd)][_0x1496f4(0x1ed)],function(_0x59f55b){const _0x303ada=_0x1496f4;_0x207bbd.#logger[_0x303ada(0x248)](LogLevel[_0x303ada(0x20e)],_0x303ada(0x1bc)+_0x59f55b[_0x303ada(0x21c)]),_0x59f55b[_0x303ada(0x21c)]==_0x303ada(0x1b3)?errorQueue[_0x303ada(0x237)]([HisPlayerError[_0x303ada(0x213)],0x0,0x0,_0x2890cc]):errorQueue[_0x303ada(0x237)]([HisPlayerError[_0x303ada(0x236)],0x0,0x0,_0x2890cc]);}),_0x193337[_0x1496f4(0x1d2)](_0x193337[_0x1496f4(0x1bd)][_0x1496f4(0x1f8)],_0x34d865=>{const _0x4780a7=_0x1496f4;_0x207bbd.#logger[_0x4780a7(0x248)](LogLevel['INFO'],_0x4780a7(0x227)+_0x34d865[_0x4780a7(0x21c)]);if(_0x34d865[_0x4780a7(0x21c)]==_0x4780a7(0x1e5))eventQueue[_0x4780a7(0x237)]([HisPlayerEvent[_0x4780a7(0x1b5)],0x0,0x0,_0x2890cc]);else{if(_0x34d865[_0x4780a7(0x21c)]==_0x4780a7(0x203)){}else{if(_0x34d865[_0x4780a7(0x21c)]=='Playing')!this.#started[_0x2890cc]&&(_0x207bbd.#started[_0x2890cc]=!![]),eventQueue[_0x4780a7(0x237)]([HisPlayerEvent[_0x4780a7(0x1a7)],0x0,0x0,_0x2890cc]);else{if(_0x34d865['detail']==_0x4780a7(0x1c6))_0x207bbd.#autoplay&&!_0x207bbd.#started[_0x2890cc]&&navigator&&navigator[_0x4780a7(0x246)][_0x4780a7(0x22f)]('Safari')&&navigator[_0x4780a7(0x246)]['includes'](_0x4780a7(0x234))&&(_0x207bbd[_0x4780a7(0x20f)](_0x2890cc),_0x207bbd[_0x4780a7(0x1ba)]()),eventQueue[_0x4780a7(0x237)]([HisPlayerEvent[_0x4780a7(0x24e)],0x0,0x0,_0x2890cc]);else{if(_0x34d865[_0x4780a7(0x21c)]==_0x4780a7(0x1eb))eventQueue['enqueue']([HisPlayerEvent['HISPLAYER_EVENT_PLAYBACK_SEEK'],0x0,0x0,_0x2890cc]);else _0x34d865[_0x4780a7(0x21c)]==_0x4780a7(0x249)&&eventQueue[_0x4780a7(0x237)]([HisPlayerEvent[_0x4780a7(0x209)],0x0,0x0,_0x2890cc]);}}}}}),_0x193337[_0x1496f4(0x1d2)](_0x193337[_0x1496f4(0x1bd)][_0x1496f4(0x228)],_0x128df8=>{const _0x4e03fd=_0x1496f4;this.#logger['log'](LogLevel[_0x4e03fd(0x1c8)],_0x4e03fd(0x1e6)+_0x128df8[_0x4e03fd(0x21c)]);}),_0x193337[_0x1496f4(0x1d2)](_0x193337[_0x1496f4(0x1bd)]['ERROR'],_0x174fe1=>{const _0x8b193a=_0x1496f4,_0x33f65d=JSON[_0x8b193a(0x21a)](_0x174fe1[_0x8b193a(0x21c)]);this.#logger[_0x8b193a(0x248)](LogLevel['ERROR'],_0x8b193a(0x23d)+_0x33f65d);}),_0x193337[_0x1496f4(0x1d2)](_0x193337[_0x1496f4(0x1bd)][_0x1496f4(0x1e0)],()=>{const _0x3232e2=_0x1496f4;this.#logger[_0x3232e2(0x248)](LogLevel['DEBUG'],'Subtitles\x20ready');}),_0x193337[_0x1496f4(0x1d2)](_0x193337[_0x1496f4(0x1bd)][_0x1496f4(0x254)],()=>{const _0x501b45=_0x1496f4;this.#logger[_0x501b45(0x248)](LogLevel[_0x501b45(0x218)],_0x501b45(0x1bb));}),_0x193337[_0x1496f4(0x1d2)](_0x193337[_0x1496f4(0x1bd)]['VIDEO_PROGRESS_TIME'],_0x11a18f=>{const _0x463cc5=_0x1496f4;this.#logger['log'](LogLevel[_0x463cc5(0x218)],_0x463cc5(0x1d3)+_0x11a18f[_0x463cc5(0x21c)]);}),_0x193337['addEventListener'](_0x193337[_0x1496f4(0x1bd)][_0x1496f4(0x1b1)],()=>{const _0x5962e0=_0x1496f4;this.#logger[_0x5962e0(0x248)](LogLevel['DEBUG'],_0x5962e0(0x201));}),_0x193337[_0x1496f4(0x1d2)](_0x193337['HisPlayerEvent'][_0x1496f4(0x1cf)],()=>{const _0x148a80=_0x1496f4;this.#logger['log'](LogLevel[_0x148a80(0x218)],_0x148a80(0x1be));}),_0x193337[_0x1496f4(0x1d2)](_0x193337['HisPlayerEvent'][_0x1496f4(0x22d)],()=>{const _0x5d510f=_0x1496f4;this.#logger['log'](LogLevel[_0x5d510f(0x218)],_0x5d510f(0x1a5));}),_0x193337[_0x1496f4(0x1d2)](_0x193337[_0x1496f4(0x1bd)][_0x1496f4(0x1ec)],()=>{const _0x8905e3=_0x1496f4;this.#logger[_0x8905e3(0x248)](LogLevel[_0x8905e3(0x218)],_0x8905e3(0x1f7));});}[_0x4e5f08(0x23b)](_0x16e3bc,_0x5c0c4f,_0x3668b4,_0x9340fd,_0x1e4252){const _0x2499cd=_0x4e5f08,_0xd35023=document['createElement'](_0x2499cd(0x1e7));_0xd35023[_0x2499cd(0x206)][_0x2499cd(0x1fa)]='fixed',_0xd35023[_0x2499cd(0x206)][_0x2499cd(0x1da)]='hidden',document[_0x2499cd(0x245)][_0x2499cd(0x1e3)](_0xd35023,document['body'][_0x2499cd(0x1b7)][0x0]),this[_0x2499cd(0x22b)][_0x2499cd(0x24c)](_0xd35023);let _0x5c94b1=_0x9340fd;const _0xd4b1e=[];typeof _0x5c94b1==='boolean'&&_0x5c94b1&&(_0x5c94b1=_0x2499cd(0x1e9)[_0x2499cd(0x1ff)](_0x5c94b1['toString']()),_0xd4b1e[_0x2499cd(0x24c)](_0x5c94b1));const _0x432be1=this['multiView']['addConfig']({'div':_0xd35023,'src':_0x5c0c4f,'autoplay':_0x3668b4,'playerConfig':{'lowLatency':!![],'bitrateConfig':{'disableABR':_0x1e4252},'bufferConfig':{'bufferingGoal':0x8,'bufferBehind':0x1}},'preferNativeSubtitleRendering':!![],'mutedAtStart':!![],'mediaOptions':_0xd4b1e});this['playerIds'][_0x2499cd(0x24c)](_0x432be1);}[_0x4e5f08(0x220)](_0x6f25ae){const _0x479fb1=_0x4e5f08;for(const _0x2f2ba4 of this['playerIds']){this.#started[_0x479fb1(0x24c)](![]);const _0x337bcf=this[_0x479fb1(0x1ef)]['getPlayer'](_0x2f2ba4);this['_addMultistreamPlayerEvents'](_0x337bcf,_0x2f2ba4);}const _0x698e90=this;this[_0x479fb1(0x1ef)]['initialize'](_0x6f25ae)[_0x479fb1(0x1ce)](()=>{const _0x16381b=_0x479fb1;_0x698e90[_0x16381b(0x1c4)]=!![];})[_0x479fb1(0x211)](_0x1794e9=>{const _0x26012a=_0x479fb1,_0xa7e4ff=JSON[_0x26012a(0x21a)](_0x1794e9);_0x698e90.#logger['log'](LogLevel[_0x26012a(0x20e)],_0xa7e4ff);}),_0x698e90.#logger[_0x479fb1(0x248)](LogLevel[_0x479fb1(0x1c8)],'SDK\x20VERSION\x20'+SDK_VERSION);}[_0x4e5f08(0x219)](){return new Promise(async _0x1840f7=>{const _0x40932f=_0x56d8,_0x149f35=await this[_0x40932f(0x1ef)]['getLicenseResquest']();playbackDurationLimit=_0x149f35[_0x40932f(0x21b)]!==undefined?_0x149f35[_0x40932f(0x21b)]:-0x1,_0x1840f7(_0x149f35['watermark']!==undefined),isDurationLimitReady=!![];});}[_0x4e5f08(0x240)](_0x2f0c3c,_0x40bd24){const _0x455dfb=_0x4e5f08;let _0x168c5f=0x0;switch(_0x40bd24){case HP_CONTENT_INFO_INDEX[_0x455dfb(0x1d4)]:_0x168c5f=this[_0x455dfb(0x24f)](_0x2f0c3c);break;case HP_CONTENT_INFO_INDEX['VIDEO_HEIGHT']:_0x168c5f=this['_getMultistreamVideoHeight'](_0x2f0c3c);break;}return _0x168c5f;}[_0x4e5f08(0x24f)](_0x513e57){const _0x240657=_0x4e5f08;if(this['multiInitialized']){const _0x236448=this[_0x240657(0x1ef)][_0x240657(0x1f3)](_0x513e57);if(!_0x236448)return 0x0;return _0x236448[_0x240657(0x1ab)]();}return 0x0;}[_0x4e5f08(0x1b9)](_0x457876){const _0x4a603a=_0x4e5f08;if(this[_0x4a603a(0x1c4)]){const _0x4bcb16=this[_0x4a603a(0x1ef)][_0x4a603a(0x1f3)](_0x457876);if(!_0x4bcb16)return 0x0;return _0x4bcb16[_0x4a603a(0x224)]();}return 0x0;}[_0x4e5f08(0x241)](){const _0x1bac1b=_0x4e5f08;if(this[_0x1bac1b(0x1c4)]){const _0x1d3be5=this[_0x1bac1b(0x1ef)][_0x1bac1b(0x1f3)](this[_0x1bac1b(0x1e4)]);if(!_0x1d3be5)return 0x0;return _0x1d3be5[_0x1bac1b(0x241)]()*0x3e8;}return 0x0;}[_0x4e5f08(0x1c5)](){const _0x31ef1b=_0x4e5f08;if(this['multiInitialized']){const _0x32da34=this['multiView'][_0x31ef1b(0x1f3)](this[_0x31ef1b(0x1e4)]);if(!_0x32da34)return 0x0;return _0x32da34[_0x31ef1b(0x1c5)]()*0x3e8;}return 0x0;}[_0x4e5f08(0x231)](){const _0x432e5d=_0x4e5f08;if(this[_0x432e5d(0x1c4)]){const _0x21363e=this[_0x432e5d(0x1ef)][_0x432e5d(0x1f3)](this[_0x432e5d(0x1e4)]);if(!_0x21363e)return![];return _0x21363e['isLive']();}return![];}[_0x4e5f08(0x1cc)](_0x1891d2){const _0xa2346a=_0x4e5f08;if(this[_0xa2346a(0x1c4)]){const _0x1ad51f=this[_0xa2346a(0x1ef)][_0xa2346a(0x1f3)](this['controlInstance']);if(!_0x1ad51f)return![];return _0x1ad51f['loadSource'](_0x1891d2);}return![];}[_0x4e5f08(0x20c)](_0x1448fd,_0x259869,_0x2f9bc5,_0x3896c4,_0x6fd5ae){const _0xd3194f=_0x4e5f08;this.#autoplay=_0x2f9bc5,this[_0xd3194f(0x23b)](_0x1448fd,_0x259869,_0x2f9bc5,_0x3896c4,_0x6fd5ae);}[_0x4e5f08(0x20f)](_0x58ee92){const _0x220f50=_0x4e5f08;this[_0x220f50(0x1e4)]=_0x58ee92;}[_0x4e5f08(0x1ba)](){const _0x3dba07=_0x4e5f08;this.#logger[_0x3dba07(0x248)](LogLevel['DEBUG'],'Resume\x20called\x20on\x20instance\x20'+this['controlInstance']);const _0x5b04ab=this[_0x3dba07(0x1ef)][_0x3dba07(0x1f3)](this[_0x3dba07(0x1e4)]);if(!_0x5b04ab)return;_0x5b04ab['isPaused']()?(_0x5b04ab[_0x3dba07(0x1b0)](),this[_0x3dba07(0x212)][this[_0x3dba07(0x1e4)]]=HisPlayerStatus[_0x3dba07(0x251)]):this.#logger[_0x3dba07(0x248)](LogLevel[_0x3dba07(0x218)],_0x3dba07(0x1b6));}[_0x4e5f08(0x1a4)](){const _0xe37903=_0x4e5f08;this.#logger['log'](LogLevel['DEBUG'],'Pause\x20called\x20on\x20instance\x20'+this[_0xe37903(0x1e4)]);const _0x4e063b=this['multiView'][_0xe37903(0x1f3)](this[_0xe37903(0x1e4)]);if(!_0x4e063b)return;!_0x4e063b['isPaused']()?(_0x4e063b['pause'](),this[_0xe37903(0x212)][this[_0xe37903(0x1e4)]]=HisPlayerStatus['HISPLAYER_STATUS_PAUSE']):this.#logger[_0xe37903(0x248)](LogLevel[_0xe37903(0x218)],_0xe37903(0x1dd));}['stopPlayer'](){const _0x2a32f2=_0x4e5f08;this.#logger[_0x2a32f2(0x248)](LogLevel[_0x2a32f2(0x218)],'Stop\x20called\x20on\x20instance\x20'+this['controlInstance']),this[_0x2a32f2(0x1c4)]?(this[_0x2a32f2(0x1a4)](),this[_0x2a32f2(0x1d8)](0x0),eventQueue[_0x2a32f2(0x237)]([HisPlayerEvent[_0x2a32f2(0x1f9)],0x0,0x0,this[_0x2a32f2(0x1e4)]]),this[_0x2a32f2(0x212)][this[_0x2a32f2(0x1e4)]]=HisPlayerStatus['HISPLAYER_STATUS_STOP']):this.#logger[_0x2a32f2(0x248)](LogLevel[_0x2a32f2(0x218)],'The\x20player\x20cannot\x20be\x20stopped');}[_0x4e5f08(0x1d8)](_0x5be2b4){const _0x4cb359=_0x4e5f08,_0x4994e0=this[_0x4cb359(0x1ef)]['getPlayer'](this[_0x4cb359(0x1e4)]);_0x4994e0&&_0x4994e0[_0x4cb359(0x1d8)](_0x5be2b4/0x3e8);}['setVolume'](_0x2a44be){const _0x2c87d1=_0x4e5f08,_0x19d0d6=this[_0x2c87d1(0x1ef)]['getPlayer'](this['controlInstance']);_0x19d0d6&&(_0x19d0d6['setMute'](![]),_0x19d0d6['setVolume'](_0x2a44be));}[_0x4e5f08(0x1b4)](_0x3de1aa,_0x404d1b,_0x42fbe7,_0x3231f5,_0x52b4a9){const _0x3e8272=_0x4e5f08;if(glManager&&this[_0x3e8272(0x1c4)]){const _0xbd8056=this[_0x3e8272(0x1ef)]['getPlayer'](_0x404d1b);glManager[_0x3e8272(0x20d)]=_0x42fbe7,glManager['bindWebGLTexture'](_0x3de1aa);const _0x1fa722=_0xbd8056['getMediaElement']();_0x1fa722['readyState']>=0x2&&(glManager[_0x3e8272(0x1d5)](_0x3231f5,_0x52b4a9,_0x1fa722),glManager[_0x3e8272(0x1ad)](_0xbd8056[_0x3e8272(0x1ab)](),_0xbd8056['getCurrentHeight']())),glManager[_0x3e8272(0x1d6)](),glManager[_0x3e8272(0x229)]();}return _0x3de1aa;}[_0x4e5f08(0x1c3)](_0x2c8a8a){const _0xfd4435=_0x4e5f08,_0x658a7b=this[_0xfd4435(0x1ef)][_0xfd4435(0x1f3)](this[_0xfd4435(0x1e4)]);_0x658a7b&&_0x658a7b[_0xfd4435(0x23e)](_0x658a7b[_0xfd4435(0x1aa)]()[_0x2c8a8a],![]);}[_0x4e5f08(0x225)](_0x5f1d91){const _0x34fb23=_0x4e5f08,_0x250f06=this[_0x34fb23(0x1ef)][_0x34fb23(0x1f3)](this[_0x34fb23(0x1e4)]);if(_0x250f06)return _0x250f06[_0x34fb23(0x1aa)]()[_0x5f1d91]['id'];return null;}[_0x4e5f08(0x20a)](){const _0x3e402c=_0x4e5f08,_0x3508c1=this[_0x3e402c(0x1ef)][_0x3e402c(0x1f3)](this[_0x3e402c(0x1e4)]);if(_0x3508c1)return _0x3508c1[_0x3e402c(0x1f1)]()['id'];return null;}[_0x4e5f08(0x1f0)](_0x10d65a){const _0x17c629=_0x4e5f08,_0x3458c2=this[_0x17c629(0x1ef)][_0x17c629(0x1f3)](this[_0x17c629(0x1e4)]);if(_0x3458c2)return _0x3458c2[_0x17c629(0x1aa)]()[_0x10d65a][_0x17c629(0x1e8)];return null;}[_0x4e5f08(0x1ae)](){const _0x261048=_0x4e5f08,_0x3c87fe=this[_0x261048(0x1ef)][_0x261048(0x1f3)](this[_0x261048(0x1e4)]);if(_0x3c87fe)return _0x3c87fe[_0x261048(0x1f1)]()['bitrate'];return null;}[_0x4e5f08(0x1b2)](_0xec5732){const _0x212abe=_0x4e5f08,_0x5296af=this[_0x212abe(0x1ef)][_0x212abe(0x1f3)](this[_0x212abe(0x1e4)]);if(_0x5296af)return _0x5296af[_0x212abe(0x1aa)]()[_0xec5732][_0x212abe(0x1fb)];return null;}['getCurrentTrackWidth'](){const _0x257eb5=_0x4e5f08,_0xf39ec8=this[_0x257eb5(0x1ef)][_0x257eb5(0x1f3)](this[_0x257eb5(0x1e4)]);if(_0xf39ec8)return _0xf39ec8[_0x257eb5(0x1f1)]()[_0x257eb5(0x1fb)];return null;}[_0x4e5f08(0x1f6)](_0x149c3b){const _0x47bae2=_0x4e5f08,_0x1d747b=this[_0x47bae2(0x1ef)]['getPlayer'](this['controlInstance']);if(_0x1d747b)return _0x1d747b[_0x47bae2(0x1aa)]()[_0x149c3b][_0x47bae2(0x1de)];return null;}[_0x4e5f08(0x1c7)](){const _0x2bd7a3=_0x4e5f08,_0x40a80e=this[_0x2bd7a3(0x1ef)]['getPlayer'](this['controlInstance']);if(_0x40a80e)return _0x40a80e['getCurrentTrack']()['height'];return null;}['getTrackCount'](){const _0x5f5b23=_0x4e5f08,_0x59904a=this[_0x5f5b23(0x1ef)]['getPlayer'](this['controlInstance']);if(_0x59904a)return _0x59904a[_0x5f5b23(0x1aa)]()['length'];return 0x0;}['getPlayerStatus'](){const _0x437805=_0x4e5f08;return this[_0x437805(0x212)][this['controlInstance']];}[_0x4e5f08(0x1a9)](){const _0x4b8cb3=_0x4e5f08;this.#logger[_0x4b8cb3(0x248)](LogLevel[_0x4b8cb3(0x218)],_0x4b8cb3(0x1ca)+this[_0x4b8cb3(0x1e4)]);const _0x184b9c=this[_0x4b8cb3(0x1ef)][_0x4b8cb3(0x1f3)](this[_0x4b8cb3(0x1e4)]);_0x184b9c&&_0x184b9c[_0x4b8cb3(0x1a9)]();}[_0x4e5f08(0x202)](){const _0x225f24=_0x4e5f08;this.#logger[_0x225f24(0x248)](LogLevel['DEBUG'],_0x225f24(0x1c2)+this['controlInstance']);const _0x4dffc9=this[_0x225f24(0x1ef)][_0x225f24(0x1f3)](this[_0x225f24(0x1e4)]);_0x4dffc9&&_0x4dffc9[_0x225f24(0x202)]();}[_0x4e5f08(0x223)](){const _0x20052c=_0x4e5f08;this[_0x20052c(0x1ef)][_0x20052c(0x23a)]()[_0x20052c(0x1ce)](()=>{const _0x449760=_0x20052c;for(const _0x5bfa4f of this[_0x449760(0x22b)]){_0x5bfa4f[_0x449760(0x226)]['removeChild'](_0x5bfa4f);}this['playerDivs']=[];}),this['multiInitialized']=![],this[_0x20052c(0x212)]=[],this[_0x20052c(0x250)]=[];}}class GLManager{static [_0x4e5f08(0x20b)]='';constructor(){const _0x57223c=_0x4e5f08;this[_0x57223c(0x20b)]=this['checkBrowser']();}[_0x4e5f08(0x21d)](_0xf94172){const _0x3b3b9f=_0x4e5f08;this[_0x3b3b9f(0x247)][_0x3b3b9f(0x242)](this[_0x3b3b9f(0x247)]['TEXTURE_2D'],_0xf94172),this[_0x3b3b9f(0x247)]['pixelStorei'](this[_0x3b3b9f(0x247)][_0x3b3b9f(0x24d)],![]);}[_0x4e5f08(0x1d6)](){const _0x17daa8=_0x4e5f08;this[_0x17daa8(0x247)][_0x17daa8(0x242)](this[_0x17daa8(0x247)]['TEXTURE_2D'],null);}[_0x4e5f08(0x1d5)](_0x4dc201,_0x2fcfd5,_0x419d3d){const _0x2a9cc4=_0x4e5f08;_0x2a9cc4(0x1ee)in this[_0x2a9cc4(0x247)]&&(screen[_0x2a9cc4(0x22e)]>0x18&&window['matchMedia'](_0x2a9cc4(0x238))[_0x2a9cc4(0x214)]?this[_0x2a9cc4(0x247)][_0x2a9cc4(0x1ee)]=_0x2a9cc4(0x1a6):this[_0x2a9cc4(0x247)][_0x2a9cc4(0x1ee)]=_0x2a9cc4(0x1dc)),this[_0x2a9cc4(0x20b)]!=='Chrome'?this['_gl']['texSubImage2D'](this[_0x2a9cc4(0x247)][_0x2a9cc4(0x1fe)],0x0,0x0,0x0,_0x4dc201,_0x2fcfd5,this['_gl'][_0x2a9cc4(0x210)],this[_0x2a9cc4(0x247)]['UNSIGNED_BYTE'],_0x419d3d):this[_0x2a9cc4(0x247)][_0x2a9cc4(0x1e1)](this[_0x2a9cc4(0x247)][_0x2a9cc4(0x1fe)],0x0,0x0,0x0,this[_0x2a9cc4(0x247)][_0x2a9cc4(0x210)],this['_gl'][_0x2a9cc4(0x1bf)],_0x419d3d);}[_0x4e5f08(0x239)](){const _0x5a0260=_0x4e5f08;let _0x363613='';if(navigator[_0x5a0260(0x246)][_0x5a0260(0x233)](_0x5a0260(0x1d1))>-0x1)_0x363613=_0x5a0260(0x1d1);else{if(navigator[_0x5a0260(0x246)][_0x5a0260(0x233)](_0x5a0260(0x1ea))>-0x1)_0x363613=_0x5a0260(0x1ea);else navigator[_0x5a0260(0x246)][_0x5a0260(0x233)]('Safari')>-0x1&&(_0x363613=_0x5a0260(0x207));}return _0x363613;}['setWebGL1Requirements'](_0x377f1b,_0x5d7207){const _0x2f938a=_0x4e5f08;this[_0x2f938a(0x23f)](_0x377f1b)&&this[_0x2f938a(0x23f)](_0x5d7207)?this['_gl'][_0x2f938a(0x1db)](this[_0x2f938a(0x247)][_0x2f938a(0x1fe)]):(this[_0x2f938a(0x247)][_0x2f938a(0x232)](this[_0x2f938a(0x247)][_0x2f938a(0x1fe)],this[_0x2f938a(0x247)][_0x2f938a(0x200)],this['_gl'][_0x2f938a(0x1fc)]),this[_0x2f938a(0x247)]['texParameteri'](this[_0x2f938a(0x247)][_0x2f938a(0x1fe)],this['_gl']['TEXTURE_WRAP_T'],this[_0x2f938a(0x247)]['CLAMP_TO_EDGE']),this[_0x2f938a(0x247)][_0x2f938a(0x232)](this[_0x2f938a(0x247)][_0x2f938a(0x1fe)],this['_gl'][_0x2f938a(0x22a)],this[_0x2f938a(0x247)][_0x2f938a(0x1d9)]));}[_0x4e5f08(0x229)](){const _0x519ebf=_0x4e5f08;this['_gl'][_0x519ebf(0x229)]();}get[_0x4e5f08(0x20d)](){const _0x2667ee=_0x4e5f08;return this[_0x2667ee(0x247)];}set['glContext'](_0x136853){const _0x1a87b4=_0x4e5f08;this[_0x1a87b4(0x247)]=_0x136853['GLctx'];}[_0x4e5f08(0x23f)](_0x1c490a){return _0x1c490a&_0x1c490a-0x1===0x0;}}let glManager=null,eventQueue=null,errorQueue=null,playbackDurationLimit=-0x1,isDurationLimitReady=![];function _0x56d8(_0x4e1cb4,_0x414a99){const _0x579c1b=_0x579c();return _0x56d8=function(_0x56d854,_0x1da8ee){_0x56d854=_0x56d854-0x1a4;let _0x2f2a16=_0x579c1b[_0x56d854];return _0x2f2a16;},_0x56d8(_0x4e1cb4,_0x414a99);}function _0x579c(){const _0x12e1e2=['_getMultistreamVideoHeight','resume','Stall\x20detected','License\x20error:\x20','HisPlayerEvent','Video\x20mid\x20point','UNSIGNED_BYTE','color:\x20lightgrey;','4ZcBkoP','Enabling\x20the\x20ABR\x20logic\x20','setCurrentTrack','multiInitialized','getDuration','Paused','getCurrentTrackHeight','INFO','210085dkxmLI','Disabling\x20the\x20ABR\x20logic\x20','substring','changeVideoContent','908196jcXVJr','then','VIDEO_MIDPOINT','dequeue','Chrome','addEventListener','Video\x20progress\x20time\x20','VIDEO_WIDTH','updateWebGLTexture','unbindWebGLTexture','setLogLevel','seek','LINEAR','visibility','generateMipmap','srgb','The\x20player\x20is\x20already\x20paused','height','isEmpty','SUBTITLES_READY','texSubImage2D','3WZwtjE','insertBefore','controlInstance','Ready','Buffer\x20type\x20','div','bitrate','loop=','Firefox','Seek','VIDEO_COMPLETE','LICENSE_ERROR','drawingBufferColorSpace','multiView','getTrackBitrate','getCurrentTrack','colorizeAndLogMessage','getPlayer','color:\x20black;\x20background:\x20#99E2B4;','length','getTrackHeight','Video\x20complete','STATE_CHANGE','HISPLAYER_EVENT_PLAYBACK_STOP','position','width','CLAMP_TO_EDGE','error','TEXTURE_2D','concat','TEXTURE_WRAP_S','Video\x20first\x20quartile','enableABR','Buffering','WARNING','replace','style','Safari','getLogType','HISPLAYER_EVENT_END_OF_CONTENT','getCurrentTrackID','browser','setMultiPaths','glContext','ERROR','changeControlInstance','RGBA','catch','multiStreamPlayerStatus','HISPLAYER_ERROR_IMPRESSIONS_LIMIT_REACHED','matches','192332HiSBZK','376453hPQybL','toISOString','DEBUG','checkWaterMark','stringify','durationLimit','detail','bindWebGLTexture','peek','getInstance','Initialize','warn','formatLogHeader','release','getCurrentHeight','getTrackID','parentNode','State\x20change\x20','BUFFER_TYPE','flush','TEXTURE_MIN_FILTER','playerDivs','_addMultistreamPlayerEvents','VIDEO_THIRD_QUARTILE','colorDepth','includes','254698HyECXM','isLive','texParameteri','indexOf','Version',']\x20[HISPlayer\x20|\x20','HISPLAYER_ERROR_GENERAL_LICENSE_ERROR','enqueue','(color-gamut:\x20p3)','checkBrowser','destroy','CreateAdditionalPlayer','1431171AziBID','Error\x20','setTrack','_isPowerOf2','getContentInfo','getCurrentTime','bindTexture','getLength','30oXBwXu','body','userAgent','_gl','log','Ended','currentContext','220816SkGYQZ','push','UNPACK_FLIP_Y_WEBGL','HISPLAYER_EVENT_PLAYBACK_PAUSE','_getMultistreamVideoWidth','playerIds','HISPLAYER_STATUS_PLAY','color:\x20black;\x20background:\x20#FFEFD5;','%c\x20\x20','STALL_DETECTED','pause','Video\x20third\x20quartile','display-p3','HISPLAYER_EVENT_PLAYBACK_PLAY','49NoIGJY','disableABR','getTracks','getCurrentWidth','logLevel','setWebGL1Requirements','getCurrentTrackBitrate','instance','play','VIDEO_FIRST_QUARTILE','getTrackWidth','Maximum\x20number\x20of\x20impressions\x20is\x20reached','updateVideoTexture','HISPLAYER_EVENT_PLAYBACK_READY','The\x20player\x20is\x20already\x20playing','childNodes','3.1.1'];_0x579c=function(){return _0x12e1e2;};return _0x579c();}function Queue(){const _0x4e5dcb=_0x4e5f08;let _0x5f257c=[],_0x5aab80=0x0;this[_0x4e5dcb(0x243)]=function(){return _0x5f257c['length']-_0x5aab80;},this[_0x4e5dcb(0x1df)]=function(){const _0x290f7b=_0x4e5dcb;return!_0x5f257c[_0x290f7b(0x1f5)];},this['enqueue']=function(_0x40f21d){const _0x5d443c=_0x4e5dcb;_0x5f257c[_0x5d443c(0x24c)](_0x40f21d);},this['dequeue']=function(){const _0x561a4a=_0x4e5dcb;if(_0x5f257c[_0x561a4a(0x1f5)]>0x0){const _0x42321b=_0x5f257c[_0x5aab80];return 0x2*++_0x5aab80>=_0x5f257c[_0x561a4a(0x1f5)]&&(_0x5f257c=_0x5f257c['slice'](_0x5aab80),_0x5aab80=0x0),_0x42321b;}},this[_0x4e5dcb(0x21e)]=function(){const _0x5c56b2=_0x4e5dcb;return _0x5f257c[_0x5c56b2(0x1f5)]>0x0?_0x5f257c[_0x5aab80]:void 0x0;};}function setUpContext(_0x2d5e6b){const _0x15812a=_0x4e5f08;glManager=new GLManager(),glManager[_0x15812a(0x20d)]=_0x2d5e6b[_0x15812a(0x24a)],eventQueue=new Queue(),errorQueue=new Queue();}let currentEvent=null;function isEventQueueEmpty(){const _0x35df7c=_0x4e5f08;if(!eventQueue)return!![];return eventQueue[_0x35df7c(0x1df)]();}function getEventAsyncCMDType(){const _0x682a4e=_0x4e5f08;if(!eventQueue)return 0x0;return currentEvent=eventQueue[_0x682a4e(0x21e)](),_eventQueuePop(),currentEvent?currentEvent[0x0]:0x0;}function getEventAsyncCMDValue(){if(!eventQueue||!currentEvent)return 0x0;return currentEvent[0x1]!==undefined||currentEvent[0x1]!==null?currentEvent[0x1]:0x0;}function getEventAsyncCMDResult(){if(!eventQueue||!currentEvent)return 0x0;return currentEvent[0x2]!==undefined||currentEvent[0x2]!==null?currentEvent[0x2]:0x0;}function HISPLAYERUnity_EventAsyncCmdPlayerIndex(){if(!eventQueue||!currentEvent)return 0x0;return currentEvent[0x3]!==undefined||currentEvent[0x3]!==null?currentEvent[0x3]:0x0;}function _eventQueuePop(){const _0x495bf1=_0x4e5f08;if(!eventQueue)return;eventQueue[_0x495bf1(0x1d0)]();}let currentError=null;function isErrorQueueEmpty(){if(!errorQueue)return!![];return errorQueue['isEmpty']();}function getErrorAsyncCMDType(){const _0xfe9db2=_0x4e5f08;if(!errorQueue)return 0x0;return currentError=errorQueue[_0xfe9db2(0x21e)](),_errorQueuePop(),currentError?currentError[0x0]:0x0;}function getErrorAsyncCMDValue(){if(!errorQueue||!currentError)return 0x0;return currentError[0x1]!==undefined||currentError[0x1]!==null?currentError[0x1]:0x0;}function getErrorAsyncCMDResult(){if(!errorQueue||!currentError)return 0x0;return currentError[0x2]!==undefined||currentError[0x2]!==null?currentError[0x2]:0x0;}function HISPLAYERUnity_ErrorAsyncCmdPlayerIndex(){if(!errorQueue||!currentError)return 0x0;return currentError[0x3]!==undefined||currentError[0x3]!==null?currentError[0x3]:0x0;}function _errorQueuePop(){const _0x4aa2bc=_0x4e5f08;if(!errorQueue)return;errorQueue[_0x4aa2bc(0x1d0)]();}function getIsDurationLimitReady(){return isDurationLimitReady;}function getPlaybackDurationLimit(){return playbackDurationLimit;}const LogLevel={'DEBUG':0x0,'INFO':0x1,'WARNING':0x2,'ERROR':0x3,'NONE':0x4};class Logger{static [_0x4e5f08(0x1af)];constructor(){const _0x58c698=_0x4e5f08;this[_0x58c698(0x1af)]=null,this[_0x58c698(0x1ac)]=LogLevel[_0x58c698(0x218)];}static[_0x4e5f08(0x21f)](){const _0x436a03=_0x4e5f08;return!Logger[_0x436a03(0x1af)]&&(Logger[_0x436a03(0x1af)]=new Logger()),Logger[_0x436a03(0x1af)];}[_0x4e5f08(0x1d7)](_0x6e6881){const _0x48fbec=_0x4e5f08;this[_0x48fbec(0x1ac)]=_0x6e6881;}[_0x4e5f08(0x208)](_0x3f05bf){const _0x5ee017=_0x4e5f08;switch(_0x3f05bf){case LogLevel[_0x5ee017(0x218)]:return'DEBUG';case LogLevel[_0x5ee017(0x1c8)]:return _0x5ee017(0x1c8);case LogLevel['WARNING']:return _0x5ee017(0x204);case LogLevel[_0x5ee017(0x20e)]:return _0x5ee017(0x20e);default:return _0x5ee017(0x218);}}[_0x4e5f08(0x222)](_0x1cd329){const _0x425012=_0x4e5f08,_0x34d988=new Date()[_0x425012(0x217)]()[_0x425012(0x205)]('T','\x20')[_0x425012(0x1cb)](0x0,0x13);return'['+_0x34d988+_0x425012(0x235)+this[_0x425012(0x208)](_0x1cd329)+']:';}[_0x4e5f08(0x1f2)](_0x5ba28d,_0x506889){const _0x540cfb=_0x4e5f08;switch(_0x5ba28d){case LogLevel[_0x540cfb(0x218)]:console[_0x540cfb(0x248)]('%c'+this['formatLogHeader'](_0x5ba28d)+_0x540cfb(0x253)+_0x506889,_0x540cfb(0x252),_0x540cfb(0x1c0));break;case LogLevel[_0x540cfb(0x1c8)]:console[_0x540cfb(0x248)]('%c'+this[_0x540cfb(0x222)](_0x5ba28d)+_0x540cfb(0x253)+_0x506889,_0x540cfb(0x1f4),'color:\x20lightgrey;');break;case LogLevel[_0x540cfb(0x204)]:console[_0x540cfb(0x221)](_0x506889);break;case LogLevel[_0x540cfb(0x20e)]:console[_0x540cfb(0x1fd)](_0x506889);break;default:console['log']('%c'+this[_0x540cfb(0x222)](_0x5ba28d)+_0x540cfb(0x253)+_0x506889,'color:\x20black;\x20background:\x20#FFEFD5;',_0x540cfb(0x1c0));break;}}[_0x4e5f08(0x248)](_0x301d1f,_0x8a3fa){const _0x3d03b8=_0x4e5f08;_0x301d1f>=this[_0x3d03b8(0x1ac)]&&this[_0x3d03b8(0x1f2)](_0x301d1f,_0x8a3fa);}}