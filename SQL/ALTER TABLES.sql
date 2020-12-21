ALTER TABLE [sendFrontol].[s_Terminal] 
ADD		
id_gu	int		null,
last_id_gu	int		null,
DateGoodsSend	datetime	null,
id_GoodsSender	int		null,
DateUserSend	datetime	null,
id_UserSender	int		null,
isActive	bit	default 1
