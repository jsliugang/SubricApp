using Newtonsoft.Json;
using Subric.SDK.API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;


namespace SubricApp
{

	public partial class MainApp : Telerik.WinControls.UI.RadForm
	{
		private SubricTargetVersion subricapp_version = SubricTargetVersion.Stable_2019_0_0;
		public System.Windows.Controls.MediaElement mediaplayerCtrl;
		public RadMenuItem plugin_menu;
		private List<CallbackActionData> CallbacksList = new List<CallbackActionData>();
		private static int callback_fps = 30;
		private int callback_Interval = callback_fps * 10;
		private bool isPlaying = false;
		private bool isLyricLoaded = false;
		private bool isMovieLoaded = false;
		private bool isRecording = false;
		private bool isFloatPlayerActive = false;
		private bool canAddSub = true;
		private string r_begin = "";
		private string media_file_name = "Untitled";
		private List<Subtitle_Object> subtitle_data = new List<Subtitle_Object>() { };
		private List<Plugin_Control> plugins_data = new List<Plugin_Control>() { };

		private class CallbackActionData
		{
			public string CallbackName { get; set; }
			public Action CallbackAction { get; set; }
		}

		private enum PlayingType
		{
			normal = 1,
			recording = 2
		}

		private PlayingType play_type = PlayingType.normal;


		private Bridge GeneratePluginAPI()
		{
			Bridge app_bridge = new Bridge()
			{

				OpenMedia = API_OpenMedia,
				GetMoviePosition = API_GetMoviePosition,
				SetMoviePosition = API_SetMoviePosition,
				PlayMovie = API_PlayMovie,
				PauseMovie = API_PauseMovie,
				StopMovie = API_StopMovie,
				GetSubtitles = API_GetSubtitles,
				SetSubtitles = API_SetSubtitles,
				GetLyrics = API_GetLyrics,
				SetLyrics = API_SetLyrics,
				GetUpcomingLyricText = API_GetUpcomingLyricText,
				SetUpcomingLyricText = API_SetUpcomingLyricText,
				AddSubtitle = API_AddSubtitle,
				AddLyric = API_AddLyric,
				ShowSubricMessageBox = API_ShowSubricMessageBox,
				ChangeStatus = API_ChangeStatus,
				GetSubricAppRoot = API_GetSubricAppRoot,
				GetPluginFolder = API_GetPluginFolder,
				GZip_CompressFile = API_GZip_CompressFile,
				GZip_DecompressFile = API_GZip_DecompressFile,
				ShowVideoStatus = API_ShowVideoStatus,
				ShowSubtitle = API_ShowSubtitle,
				ShowSubtitleForMs = API_ShowSubtitleForMs,
				HideSubtitle = API_HideSubtitle,
				SetLyricLoaded = API_SetLyricLoaded,
				RegisterCallback = API_RegisterCallback,
				UnegisterCallback = API_UnegisterCallback,
				ChangePreviewSubtitleDefaultColor = API_ChangePreviewSubtitleDefaultColor,
				ResetPreviewSubtitleDefaultColor = API_ResetPreviewSubtitleDefaultColor

			};
			return app_bridge;
		}

		private void PluginManager_LoadPlugins()
		{
			state_of_app.Text = "Loading Plugins ...";

			string[] plugin_files = System.IO.Directory.GetFiles((Environment.CurrentDirectory + "\\plugins"), "*.dll");
			Bridge plugin_bridge = GeneratePluginAPI();

			foreach (string plugin_address in plugin_files)
			{

				try
				{
					PluginManager_LoadPlugin(plugin_address, plugin_bridge);
				}
				catch (Exception error)
				{
					RadMessageBox.Show($"Cannot load plugin file ({plugin_address})\r\nError: {error.Message} at {error.Source}", "Invalid Plugin!", MessageBoxButtons.OK, RadMessageIcon.Error);
				}

			}

			if (plugins_data.Count != 0)
			{
				plugin_menu = new RadMenuItem("Plugins");
				AppMenu.Items.Insert(3, plugin_menu);
				ToolBox.Items.Insert(9, new CommandBarSeparator());

			}


			for (int i = 0; i < plugins_data.Count; i++)
			{
				bool create_menu = false;
				bool create_icon = false;
				bool startup_execute = false;

				Plugin_Control sel_plugin = plugins_data[i];

				if (sel_plugin.plugin_showtype == SubricPluginShowType.MENU_AND_ICON) { create_menu = create_icon = true; startup_execute = false; }
				if (sel_plugin.plugin_showtype == SubricPluginShowType.ICON_ONLY) { create_menu = false; create_icon = true; startup_execute = false; }
				if (sel_plugin.plugin_showtype == SubricPluginShowType.MENU_ONLY) { create_menu = true; create_icon = false; startup_execute = false; }
				if (sel_plugin.plugin_showtype == SubricPluginShowType.STARTUP_ONLY) { create_menu = false; create_icon = false; startup_execute = true; }
				if (sel_plugin.plugin_showtype == SubricPluginShowType.STARTUP_AND_ICON) { create_menu = false; create_icon = true; startup_execute = true; }
				if (sel_plugin.plugin_showtype == SubricPluginShowType.STARTUP_AND_MENU) { create_menu = true; create_icon = false; startup_execute = true; }
				if (sel_plugin.plugin_showtype == SubricPluginShowType.ALL_OPTIONS) { create_menu = true; create_icon = true; startup_execute = true; }


				if (create_menu)
				{
					RadMenuItem plugin_local_menu = new RadMenuItem(sel_plugin.plugin_name);
					plugin_local_menu.Click += (o, s) =>
					{
						try
						{
							sel_plugin.plugin_exe.Invoke(sel_plugin.plugin_handle, null);
						}
						catch (Exception error) { MessageBox.Show($"Plugin Error : {error.Message}", "Plugin Crashed [0x50C00C3]"); }
					};
					plugin_local_menu.ToolTipText = $"Version : {sel_plugin.plugin_version}\r\nAuthor :{sel_plugin.plugin_author}";
					plugin_menu.Items.Add(plugin_local_menu);
				}

				if (create_icon)
				{
					CommandBarButton plugin_local_icon = new CommandBarButton();
					plugin_local_icon.Click += (o, s) =>
					{
						try
						{
							sel_plugin.plugin_exe.Invoke(sel_plugin.plugin_handle, null);
						}
						catch (Exception error) { MessageBox.Show($"Plugin Error : {error.Message}", "Plugin Crashed [0x662C1B0]"); }
					};

					plugin_local_icon.DisplayName = sel_plugin.plugin_name;
					plugin_local_icon.Image = sel_plugin.plugin_icon;
					plugin_local_icon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
					plugin_local_icon.Name = sel_plugin.plugin_name + "_toolbar_btn";
					plugin_local_icon.Padding = new System.Windows.Forms.Padding(5);
					plugin_local_icon.ToolTipText = $"Plugin : {sel_plugin.plugin_name}\r\nVersion : {sel_plugin.plugin_version}\r\nAuthor :{sel_plugin.plugin_author}";
					ToolBox.Items.Insert(ToolBox.Items.IndexOf(RecordSubIcon) - 1, plugin_local_icon);
				}

				if (startup_execute)
				{
					try
					{
						sel_plugin.plugin_exe.Invoke(sel_plugin.plugin_handle, null);
					}
					catch (Exception error) { MessageBox.Show($"Plugin Error : {error.Message}", "Plugin Crashed [0x02C0FF0]"); }
				}


				sel_plugin.is_loaded = true;
			}


			state_of_app.Text = "Ready!";
		}

		private void PluginManager_LoadPlugin(string pluginfile, Bridge bridge_ex)
		{
			Assembly plugin_asm = Assembly.LoadFile(pluginfile);
			string plugin_namespace = System.IO.Path.GetFileNameWithoutExtension(pluginfile);

			Type plugin = plugin_asm.GetType("Subric.Plugin.subric_plugin");
			object plugin_handle = Activator.CreateInstance(plugin);

			MethodInfo plugin_init = plugin.GetMethod("Init");
			if (plugin_init == null)
			{
				throw new Exception("Cannot Initialize Plugin!");
			}

			plugin_init.Invoke(plugin_handle, new object[] { bridge_ex });

			MethodInfo execute_init = plugin.GetMethod("Execute");
			if (execute_init == null)
			{
				throw new Exception("Cannot Find Execution Method!");
			}

			string get_plugin_name = (string)plugin.GetField("_plugin_name").GetValue(null);
			string get_plugin_ver = (string)plugin.GetField("_plugin_version").GetValue(null);
			string get_plugin_author = (string)plugin.GetField("_plugin_author").GetValue(null);
			SubricTargetVersion get_plugin_subrictarget = (SubricTargetVersion)plugin.GetField("_plugin_subrictarget").GetValue(null);
			SubricPluginShowType get_plugin_showtype = (SubricPluginShowType)plugin.GetField("_plugin_showtype").GetValue(null);
			Bitmap get_plugin_icon = (Bitmap)plugin.GetField("_plucin_icon").GetValue(null);

			Plugin_Control newplugin = new Plugin_Control()
			{
				plugin_name = get_plugin_name,
				plugin_version = get_plugin_ver,
				plugin_author = get_plugin_author,
				plugin_target = get_plugin_subrictarget,
				plugin_showtype = get_plugin_showtype,
				plugin_exe = execute_init,
				is_loaded = false,
				plugin_icon = get_plugin_icon,
				plugin_handle = plugin_handle
			};


			if (newplugin.plugin_target == SubricTargetVersion.All_Versions)
			{
				plugins_data.Add(newplugin);
			}
			else
			{
				if (newplugin.plugin_target == subricapp_version)
				{
					plugins_data.Add(newplugin);
				}
				else
				{
					RadMessageBox.Show($"Sorry! This plugin ({pluginfile}) is not designed for this version of SubricApp :(", "Invalid Plugin Version", MessageBoxButtons.OK, RadMessageIcon.Error);
				}

			}




		}


		private void LoadSubricTool(string filename)
		{

			Assembly tool_asm = Assembly.Load(Subric.Compression.GZCompressor.Decompress(System.IO.File.ReadAllBytes(filename)));

			Type tool = tool_asm.GetType("SubToolGeneric.SubTool");
			object tool_handle = Activator.CreateInstance(tool);

			MethodInfo tool_launch = tool.GetMethod("LaunchTool");
			if (tool_launch == null) { throw new Exception("Cannot Load Tool!"); }

			List<string> lyrical_toolkit = (List<string>)tool_launch.Invoke(tool_handle, null);

			if (lyrical_toolkit != null)
			{
				API_SetLyrics(lyrical_toolkit);
				API_SetLyricLoaded();
			}

		}

		private async void PlayingCallbackExecuter()
		{
			try
			{
				if (isPlaying)
				{
					for (int i = 0; i < CallbacksList.Count; i++)
					{
						CallbacksList[i].CallbackAction();
					}
					await Task.Delay(callback_Interval);
					PlayingCallbackExecuter();
				}
			}
			catch (Exception error) { MessageBox.Show($"Plugin Error : {error.Message}", "Plugin Crashed [0x07C51EB]"); }


		}
		private async void RecordingCallbackExecuter()
		{
			try
			{
				if (isRecording)
				{
					for (int i = 0; i < CallbacksList.Count; i++)
					{
						CallbacksList[i].CallbackAction();
					}
					await Task.Delay(callback_Interval);
					RecordingCallbackExecuter();
				}
			}
			catch (Exception error) { MessageBox.Show($"Plugin Error : {error.Message}", "Plugin Crashed [0x076F15C]"); }
		}


		public MainApp()
		{
			InitializeComponent();

			LoadSettings();

			ThemeResolutionService.LoadPackageResource(@"SubricApp.Themes.SubricTheme.subtheme");

			ThemeResolutionService.ApplicationThemeName = "SubricTheme";
			Player_Panel.AllowedDockState = AllowedDockState.Docked;
			PlayerCtrl_Panel.AllowedDockState = AllowedDockState.Docked;
			Data_Panel.AllowedDockState = AllowedDockState.Docked;
			Prop_Panel.AllowedDockState = AllowedDockState.Docked;
			Subs_Panel.AllowedDockState = AllowedDockState.Docked;
			UpcomingLyric_Panel.AllowedDockState = AllowedDockState.Docked;
			Recorder_Panel.AllowedDockState = AllowedDockState.Docked;


			DragDropService service = dock_stage.GetService<DragDropService>();
			service.PreviewDockPosition += new DragDropDockPositionEventHandler(OnDragDropService_PreviewDockPosition);

			ContextMenuService menuService = dock_stage.GetService<ContextMenuService>();
			menuService.ContextMenuDisplaying += menuService_ContextMenuDisplaying;

			mediaplayerCtrl = MediaPlayerCore.MasterMediaCtrl;

			LyricList.AutoSizeItems = false;
			SubDataList.AutoSizeItems = false;
			SubDataList.ItemHeight = appsettings.lyriclistspace;
			LyricList.ItemHeight = appsettings.lyriclistspace;

			sub_editor.ContextMenuOpening += (p, s) =>
			{
				s.Cancel = true;
			};



			Width = appsettings.startUpSize.X; Height = appsettings.startUpSize.Y;
			if (appsettings.fullscreen) { WindowState = FormWindowState.Maximized; }

			if (System.IO.File.Exists("tools\\lywriter.subrictool"))
			{
				radMenuItem3.Enabled = true;
			}

			if (System.IO.File.Exists("tools\\subdirect.subrictool"))
			{
				radMenuItem4.Enabled = true;
			}


			PluginManager_LoadPlugins();

		}

		private void OnDragDropService_PreviewDockPosition(object sender, DragDropDockPositionEventArgs e)
		{

			DragDropService service = (DragDropService)sender;
			service.AllowedDockManagerEdges = AllowedDockPosition.None;
			e.AllowedDockPosition = AllowedDockPosition.None;


		}

		private void menuService_ContextMenuDisplaying(object sender, ContextMenuDisplayingEventArgs e)
		{

			e.Cancel = true;
		}

		private void SaveSettings()
		{
			AppSettings_Def new_settings = new AppSettings_Def()
			{
				ExportKey = Hotkeys.ExportKey,
				ImportKey = Hotkeys.ImportKey,
				OpenKey = Hotkeys.OpenKey,
				RecordKey = Hotkeys.RecordKey,
				StartRecordKey = Hotkeys.StartRecordKey,
				StopRecordKey = Hotkeys.StopRecordKey,

				fullscreen = appsettings.fullscreen,
				startUpSize = appsettings.startUpSize,
				splashscreen = appsettings.splashscreen,
				colorizing_srt = appsettings.colorizing_srt,
				lyric_height = appsettings.lyriclistspace,

				speed_scale = appsettings.speedscale,
				movement_durration = appsettings.movementdurration,
				show_overlay = appsettings.showoverlay,
				colorizing_sub = appsettings.colorizing_sub

			};
			string output_json = JsonConvert.SerializeObject(new_settings, Formatting.Indented);
			System.IO.File.WriteAllText("appconfigs\\configs_app.subjs", output_json);

		}

		private void LoadSettings()
		{
			if (System.IO.File.Exists("appconfigs\\configs_app.subjs"))
			{
				try
				{
					AppSettings_Def appsetting_recovered = JsonConvert.DeserializeObject<AppSettings_Def>(
					System.IO.File.ReadAllText("appconfigs\\configs_app.subjs"));

					Hotkeys.ExportKey = appsetting_recovered.ExportKey;
					Hotkeys.ImportKey = appsetting_recovered.ImportKey;
					Hotkeys.OpenKey = appsetting_recovered.OpenKey;
					Hotkeys.RecordKey = appsetting_recovered.RecordKey;
					Hotkeys.StartRecordKey = appsetting_recovered.StartRecordKey;
					Hotkeys.StopRecordKey = appsetting_recovered.StopRecordKey;

					appsettings.fullscreen = appsetting_recovered.fullscreen;
					appsettings.startUpSize = appsetting_recovered.startUpSize;
					appsettings.splashscreen = appsetting_recovered.splashscreen;
					appsettings.colorizing_srt = appsetting_recovered.colorizing_srt;
					appsettings.lyriclistspace = appsetting_recovered.lyric_height;

					appsettings.speedscale = appsetting_recovered.speed_scale;
					appsettings.movementdurration = appsetting_recovered.movement_durration;
					appsettings.showoverlay = appsetting_recovered.show_overlay;
					appsettings.colorizing_sub = appsetting_recovered.colorizing_sub;



				}
				catch { }

			}

		}

		private void media_play_Click(object sender, EventArgs e)
		{

			if (isMovieLoaded)
			{
				mediaplayerCtrl.Volume = 1;
				mediaplayerCtrl.Play();
				play_type = PlayingType.normal;
				isPlaying = true;
				VideoTime_Timer.Enabled = true;
				PlayingCallbackExecuter();
				RecordSubIcon.Visibility = ElementVisibility.Collapsed;
				MediaPlayerCore.UpdateState("Played");
			}
			else
			{
				RadMessageBox.Show("Please load a movie first!", "No Media Found!", MessageBoxButtons.OK, RadMessageIcon.Error);
			}

		}

		private void media_pause_Click(object sender, EventArgs e)
		{
			mediaplayerCtrl.Pause();
			isPlaying = false;
			VideoTime_Timer.Enabled = false;
			RecordSubIcon.Visibility = ElementVisibility.Visible;
			MediaPlayerCore.UpdateState("Paused");
		}

		private void media_stop_Click(object sender, EventArgs e)
		{
			mediaplayerCtrl.Stop();
			isPlaying = false;
			VideoTime_Timer.Enabled = false;
			RecordSubIcon.Visibility = ElementVisibility.Visible;
			MediaPlayerCore.UpdateState("Stopped");
		}

		private async void media_backward_Click(object sender, EventArgs e)
		{

			mediaplayerCtrl.Position -= TimeSpan.FromMilliseconds(appsettings.movementdurration);
			mediaplayerCtrl.Play();
			await Task.Delay(10);
			if (!isPlaying)
			{
				mediaplayerCtrl.Pause();
			}
			MediaPlayerCore.UpdateState($"Backwarded : {appsettings.movementdurration}ms");

		}

		private async void media_foreward_Click(object sender, EventArgs e)
		{
			mediaplayerCtrl.Position += TimeSpan.FromMilliseconds(appsettings.movementdurration);
			mediaplayerCtrl.Play();
			await Task.Delay(10);
			if (!isPlaying)
			{
				mediaplayerCtrl.Pause();
			}
			MediaPlayerCore.UpdateState($"Forwarded : {appsettings.movementdurration}ms");
		}

		private void media_speedup_Click(object sender, EventArgs e)
		{
			mediaplayerCtrl.SpeedRatio += (double)appsettings.speedscale;
			MediaPlayerCore.UpdateState($"Speed : {mediaplayerCtrl.SpeedRatio}");
		}

		private void media_speeddown_Click(object sender, EventArgs e)
		{
			mediaplayerCtrl.SpeedRatio -= (double)appsettings.speedscale;
			MediaPlayerCore.UpdateState($"Speed : {mediaplayerCtrl.SpeedRatio}");
		}

		private void media_settings_Click(object sender, EventArgs e)
		{
			MediaPlayerCore.UpdateState("Settings");
			PlayerSettings optiondialog = new PlayerSettings();
			optiondialog.UpdateValues(appsettings.speedscale, appsettings.movementdurration, appsettings.showoverlay, appsettings.colorizing_sub);
			if (optiondialog.ShowDialog() == DialogResult.OK)
			{
				appsettings.movementdurration = optiondialog.movementdurration;
				appsettings.showoverlay = optiondialog.showoverlay;
				appsettings.speedscale = optiondialog.speedscale;
				appsettings.colorizing_sub = optiondialog.colorizing_sub;
				UpdateOverlay(appsettings.showoverlay);
			}
			optiondialog.Dispose();

		}

		private void CenterPCtrlBox()
		{
			int pctrl_boxsizew = PlayerCommandBar.Size.Width / 2;
			int pctrl_sizew = (ControlBoxToolbar.Size.Width) / 2;
			ControlBoxToolbar.Margin = new Padding(pctrl_boxsizew - 136, 2, 0, 0);
		}

		private void UpdateOverlay(bool overlaydata)
		{
			if (overlaydata)
			{
				MediaPlayerCore.Overlay_Data_01.Visibility = System.Windows.Visibility.Visible;
			}
			else
			{
				MediaPlayerCore.Overlay_Data_01.Visibility = System.Windows.Visibility.Hidden;
			}
		}

		private void MainApp_SizeChanged(object sender, EventArgs e)
		{
			CenterPCtrlBox();
		}

		private void MainApp_Load(object sender, EventArgs e)
		{
			if (System.IO.File.Exists("appconfigs\\configs_panels.subjs"))
			{
				dock_stage.LoadFromXml("appconfigs\\configs_panels.subjs");
			}

			CenterPCtrlBox();
		}

		private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
		{
			dock_stage.SaveToXml("appconfigs\\configs_panels.subjs");
			SaveSettings();
		}

		private void MainApp_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Hotkeys.ImportKey && e.Control)
			{
				ImportDataMenu_Click(null, null);
			}


			if (e.KeyCode == Hotkeys.ExportKey && e.Control)
			{
				ExportSTRIcon_Click(null, null);
			}


			if (e.KeyCode == Hotkeys.OpenKey && e.Control)
			{
				OpenMediaIcon_Click(null, null);
			}


			if (e.KeyCode == Hotkeys.StartRecordKey && e.Control)
			{
				StartRecording();
				RecordSubIcon.CheckState = CheckState.Checked;
			}


			if (e.KeyCode == Hotkeys.StopRecordKey && e.Control)
			{
				if (isRecording)
				{
					StopRecording();
					RecordSubIcon.CheckState = CheckState.Unchecked;
				}
			}

			if (e.KeyCode == Hotkeys.FloatPlayerKey && e.Control)
			{
				FloatPlayerEnable();
			}

			if (e.KeyCode == Hotkeys.WriterToolKey && e.Control)
			{
				radMenuItem3_Click(null, null);
			}


		}

		private void Recorder_Panel_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Hotkeys.RecordKey)
			{

				if (isRecording)
				{


					recordStat1.BackColor = Color.White;
					recordStat1.changetext("Recording");

					if (canAddSub)
					{
						canAddSub = false;
						r_begin = new DateTime(mediaplayerCtrl.Position.Ticks).ToString("HH:mm:ss,fff");


						if (appsettings.colorizing_sub)
						{
							MediaPlayerCore.subtitle_preview.Foreground = new System.Windows.Media.SolidColorBrush(
							System.Windows.Media.Color.FromRgb(
							SubColorPicker.BackColor.R,
							SubColorPicker.BackColor.G,
							SubColorPicker.BackColor.B
							));
						}
						else
						{
							MediaPlayerCore.subtitle_preview.Foreground = new System.Windows.Media.SolidColorBrush(
							System.Windows.Media.Color.FromRgb(253, 172, 0));
						}

						MediaPlayerCore.ShowSub(get_subtext());

						upcome_output.Text = get_uplcoming_subtext();

						try
						{
							LyricList.Items[subtitle_data.Count].ForeColor = SubColorPicker.BackColor;
							LyricList.ScrollToItem(LyricList.Items[subtitle_data.Count]);
						}
						catch { }

					}


				}

			}

		}

		private void Recorder_Panel_KeyUp(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Hotkeys.RecordKey)
			{
				if (isRecording)
				{


					Subtitle_Object newsub = new Subtitle_Object()
					{
						_id = subtitle_data.Count,
						_color = SubColorPicker.BackColor,
						_start = r_begin,
						_end = new DateTime(mediaplayerCtrl.Position.Ticks).ToString("HH:mm:ss,fff"),
						_pos = new Point(0, 0),
						_text = get_subtext(),
						_Convert = ConvertText.normal,
						_isBold = false,
						_isItalic = false
					};

					subtitle_data.Add(newsub);

					RadListDataItem new_virtual_item = new RadListDataItem
					{
						Text = $"{newsub._id} - [{newsub._start}->{newsub._end}] - {newsub._text}",
						Tag = newsub._id,
						ForeColor = newsub._color
					};
					SubDataList.Items.Add(new_virtual_item);
					SubDataList.ScrollToItem(SubDataList.Items[SubDataList.Items.Count - 1]);
					SubDataList.SelectedItem = new_virtual_item;

					recordStat1.BackColor = Color.FromArgb(255, 250, 164, 0);
					recordStat1.changetext("Idle");

					canAddSub = true;

					MediaPlayerCore.HideSub();

					try
					{
						LyricList.Items[subtitle_data.Count - 1].Enabled = false;
						LyricList.Items[subtitle_data.Count - 1].ForeColor = Color.FromArgb(255, 76, 76, 76);


					}
					catch { }

				}

			}
		}

		private string get_subtext()
		{
			string subtext;

			try
			{
				subtext = LyricList.Items[subtitle_data.Count].Text;
			}
			catch
			{
				subtext = "<-------Empty------->";
			}

			return subtext;
		}

		private string get_uplcoming_subtext()
		{
			string subtext;

			try
			{
				subtext = LyricList.Items[subtitle_data.Count + 1].Text;
			}
			catch
			{
				subtext = "<-------Empty------->";

			}

			return subtext;
		}

		private async void OpenMedia()
		{
			if (!isMovieLoaded)
			{
				mediaplayerCtrl.Source = null;

				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = "Mp4 Files (*.mp4)|*.mp4|Mp3 Files (*.mp3)|*.mp3",
					RestoreDirectory = true
				};

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					mediaplayerCtrl.Source = new Uri(openFileDialog.FileName, UriKind.Relative);
					state_of_app.Text = $"File ({openFileDialog.FileName}) loaded in player.";
					Text = $"[ SubricApp ] - 2019.0.0 Stable - ({openFileDialog.FileName})";



					if (openFileDialog.FilterIndex == 1)
					{
						MediaPlayerCore.mp3screenoverlay.Visibility = System.Windows.Visibility.Hidden;
						mediaplayerCtrl.Play();
						await Task.Delay(20);
						mediaplayerCtrl.Pause();
						mediaplayerCtrl.Position = TimeSpan.FromMilliseconds(1);
						mediaplayerCtrl.Stop();
					}

					if (openFileDialog.FilterIndex == 2)
					{

						MediaPlayerCore.mp3screenoverlay.Visibility = System.Windows.Visibility.Visible;
						MediaPlayerCore.buffering_overlay.Visibility = System.Windows.Visibility.Visible;
						await Task.Delay(500);
						mediaplayerCtrl.Play();

						await Task.Delay(1000);

						media_stop_Click(null, null);
						mediaplayerCtrl.Position = TimeSpan.FromMilliseconds(1);
						MediaPlayerCore.buffering_overlay.Visibility = System.Windows.Visibility.Hidden;

					}

					isMovieLoaded = true;

					media_file_name = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);


				}

			}
			else
			{
				DialogResult askingdialog = RadMessageBox.Show($"Media loading currently is limited.\r\nYou already loaded media.\r\n\nDo you want to load a new movie ?\r\nWarning : All data clears before unloading movie.", "Limits", MessageBoxButtons.YesNo, RadMessageIcon.Error);
				if (askingdialog == DialogResult.Yes)
				{
					Hide();
					System.Diagnostics.Process.Start(
						Environment.CurrentDirectory + "\\" + System.Diagnostics.Process.GetCurrentProcess().ProcessName
						);
					Environment.Exit(0xC140);
				}


			}

		}

		private void OpenMediaIcon_Click(object sender, EventArgs e)
		{
			OpenMedia();
		}

		private void OpenMediaMenu_Click(object sender, EventArgs e)
		{
			OpenMedia();
		}

		private void StartRecording()
		{
			if (isMovieLoaded)
			{

				if (isLyricLoaded)
				{

					Recorder_Panel.Focus();
					isRecording = true;
					mediaplayerCtrl.Volume = 1;
					mediaplayerCtrl.Play();
					PlayerCtrl_Panel.Hide();
					PlayerCommandArea.Visible = false;
					VideoTime_Timer.Enabled = true;
					RecordingCallbackExecuter();
					play_type = PlayingType.recording;
					MediaPlayerCore.UpdateState("Recording");
				}
				else
				{
					RecordSubIcon.CheckState = CheckState.Unchecked;
					RadMessageBox.Show("Please import lyric to perform recording :)", "No Lyric Data Found!", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
					ImportDataMenu_Click(null, null);
				}


			}
			else
			{
				RecordSubIcon.CheckState = CheckState.Unchecked;
				RadMessageBox.Show("Record What!? :|", "No Media Found!", MessageBoxButtons.OK, RadMessageIcon.Error);
			}



		}

		private void StopRecording()
		{
			MediaPlayerCore.UpdateState("Stop Recording");
			isRecording = false;
			dock_stage.Focus();
			mediaplayerCtrl.Pause();
			MediaPlayerCore.Focus();
			PlayerCtrl_Panel.Show();
			PlayerCommandArea.Visible = true;
			CenterPCtrlBox();
			VideoTime_Timer.Enabled = false;
			MediaPlayerCore.HideSub();
			Recorder_Panel_KeyDown(null, new KeyEventArgs(Keys.Space));

		}

		private async void Recorder_Panel_Leave(object sender, EventArgs e)
		{

			if (isRecording)
			{
				dock_stage.Focus();
				await Task.Delay(10);
				Recorder_Panel.Focus();
			}
		}

		private void RecordSubIcon_CheckStateChanged(object sender, EventArgs e)
		{

			if (RecordSubIcon.CheckState == CheckState.Checked)
			{
				StartRecording();
				state_of_app.Text = "Recording ...";
			}

			if (RecordSubIcon.CheckState == CheckState.Unchecked)
			{
				StopRecording();
				state_of_app.Text = "Recording Finished.";
			}

		}

		private void VideoTime_Timer_Tick(object sender, EventArgs e)
		{
			try
			{
				DateTime timedatformat = new DateTime(mediaplayerCtrl.Position.Ticks);
				string time_passed = timedatformat.ToString("HH:mm:ss:fff");

				DateTime timedatformat2 = new DateTime(mediaplayerCtrl.NaturalDuration.TimeSpan.Ticks);
				string total_time = timedatformat2.ToString("HH:mm:ss:fff");

				MediaPlayerCore.Overlay_Data_01.Content = $"{time_passed}/{total_time} - {play_type.ToString().ToUpper()}";
			}
			catch
			{
				MediaPlayerCore.Overlay_Data_01.Content = "Buffering Error";
			}

		}

		private void SubColorPicker_Click(object sender, EventArgs e)
		{
			RadColorDialog new_cpick = new RadColorDialog
			{
				SelectedColor = SubColorPicker.BackColor,

				Icon = Icon
			};
			if (new_cpick.ShowDialog() == DialogResult.OK)
			{
				SubColorPicker.BackColor = SubColorPicker.BackColor2 = SubColorPicker.BackColor3 = SubColorPicker.BackColor4 =
				new_cpick.SelectedColor;
			}
			new_cpick.Dispose();
		}

		private void radMenuItem6_Click(object sender, EventArgs e)
		{
			AboutForm aboutx = new AboutForm();
			aboutx.ShowDialog();
		}

		private void ImportDataMenu_Click(object sender, EventArgs e)
		{
			LyricImporter lyrimp = new LyricImporter();

			if (lyrimp.ShowDialog() == DialogResult.OK)
			{
				isLyricLoaded = true;
				state_of_app.Text = "Lyric data imported!";
				LyricList.Items.AddRange(lyrimp.lyric_list);
				upcome_output.Text = get_subtext();
			}


			lyrimp.Dispose();
		}

		private void SubDataList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
		{
			try
			{
				sub_editor.SelectedObject = subtitle_data[SubDataList.SelectedIndex];
			}
			catch
			{
				sub_editor.SelectedObject = null;
			}
		}

		private void sub_editor_Edited(object sender, PropertyGridItemEditedEventArgs e)
		{

			Subtitle_Object getval = (Subtitle_Object)sub_editor.SelectedObject;
			state_of_app.Text = $"Subtitle number {getval._id} has been edited.";

			SubDataList.Items[getval._id].Text = $"{getval._id} - [{getval._start}->{getval._end}] - {getval._text}";
			SubDataList.Items[getval._id].Tag = getval._id;
			SubDataList.Items[getval._id].ForeColor = getval._color;

		}

		private void AddSubBtn_Click(object sender, EventArgs e)
		{
			Subtitle_Object newsub = new Subtitle_Object()
			{
				_id = subtitle_data.Count,
				_color = SubColorPicker.BackColor,
				_start = new DateTime(mediaplayerCtrl.Position.Ticks).ToString("HH:mm:ss,fff"),
				_end = new DateTime(mediaplayerCtrl.Position.Ticks).ToString("HH:mm:ss,fff"),
				_pos = new Point(0, 0),
				_text = "<------Empty Sub------->",
				_Convert = ConvertText.normal,
				_isBold = false,
				_isItalic = false
			};

			subtitle_data.Add(newsub);

			RadListDataItem new_virtual_item = new RadListDataItem
			{
				Text = $"{newsub._id} - [{newsub._start}->{newsub._end}] - {newsub._text}",
				Tag = newsub._id,
				ForeColor = newsub._color
			};
			SubDataList.Items.Add(new_virtual_item);
			SubDataList.ScrollToItem(SubDataList.Items[SubDataList.Items.Count - 1]);
			SubDataList.SelectedItem = new_virtual_item;
		}

		private void RemoveSubBtn_Click(object sender, EventArgs e)
		{
			if (SubDataList.Items.Count != 0)
			{
				if (RadMessageBox.Show("Are You Sure ?", "Warning !", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
				{
					int selected_id = SubDataList.Items.Count - 1;
					SubDataList.Items.Remove(SubDataList.SelectedItem);
					subtitle_data.RemoveAt(selected_id);
				}
			}
		}

		private void ExportSTRMenu_Click(object sender, EventArgs e)
		{
			Export_STR();
		}

		private void ExportSTRIcon_Click(object sender, EventArgs e)
		{
			Export_STR();
		}

		private static string HexConverter(Color c)
		{
			return ("#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2")).ToUpper();
		}

		private void Export_STR()
		{
			try
			{
				SaveFileDialog openFileDialog = new SaveFileDialog
				{
					Filter = "Subtitle SRT Files (*.srt)|*.srt|All files (*.*)|*.*",
					RestoreDirectory = true,
					Title = "Select your saving srt file :",
					FileName = media_file_name + ".srt"
				};
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string subdataexport = "";

					for (int i = 0; i < subtitle_data.Count; i++)
					{
						Subtitle_Object sub_obj = subtitle_data[i];
						if (appsettings.colorizing_srt)
						{
							subdataexport += $"{sub_obj._id + 1}\r\n{sub_obj._start} --> {sub_obj._end}\r\n<font color=\"{HexConverter(sub_obj._color)}\">{sub_obj._text}</font>\r\n\r\n";
						}
						else
						{
							subdataexport += $"{sub_obj._id + 1}\r\n{sub_obj._start} --> {sub_obj._end}\r\n{sub_obj._text}\r\n\r\n";
						}
					}


					System.IO.File.WriteAllText(openFileDialog.FileName, subdataexport);

					RadMessageBox.Show($"Your subric file successfully exported in ({openFileDialog.FileName}) ", "Task Done!", MessageBoxButtons.OK, RadMessageIcon.Info);
				}

			}
			catch
			{
				RadMessageBox.Show($"Cannot complete your request :(", "Something Went Wrong!", MessageBoxButtons.OK, RadMessageIcon.Error);
			}

		}

		private void radMenuItem2_Click(object sender, EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(System.IO.File.ReadAllText("Github"));
			}
			catch { }
		}

		private void SettingsMenu_Click(object sender, EventArgs e)
		{
			AppSettings settingeditor = new AppSettings();
			settingeditor.ShowDialog();
		}

		private void ExitMenu_Click(object sender, EventArgs e)
		{
			Close();
			Environment.Exit(0x61FF);
		}

		private void TrimBackBtn_Click(object sender, EventArgs e)
		{
			if (SubDataList.Items.Count >= 2)
			{
				int sub_indx = SubDataList.SelectedIndex;
				if (sub_indx == 0)
				{

					DialogResult ask_to_do = RadMessageBox.Show("You are extending first subtitle,in this case start time will be zero.\r\nAre you sure?", "Subtitle Extending"
					, MessageBoxButtons.YesNo, RadMessageIcon.Question);
					if (ask_to_do == DialogResult.Yes)
					{
						subtitle_data[sub_indx]._start = "00:00:00,000";
						sub_editor_Edited(null, null);
						SubDataList.Focus();
					}
				}
				else
				{
					subtitle_data[sub_indx]._start = subtitle_data[sub_indx - 1]._end;
					MediaPlayerCore.UpdateState("Subtitle Extended!");
					sub_editor_Edited(null, null);
					SubDataList.Focus();
				}
			}
		}

		private void ExtendNextBtn_Click(object sender, EventArgs e)
		{
			if (SubDataList.Items.Count >= 2)
			{
				int sub_indx = SubDataList.SelectedIndex;
				if (sub_indx == SubDataList.Items.Count - 1)
				{

					DialogResult ask_to_do = RadMessageBox.Show("You are extending last subtitle,in this case end time will be media's length.\r\nAre you sure?", "Subtitle Extending"
					, MessageBoxButtons.YesNo, RadMessageIcon.Question);
					if (ask_to_do == DialogResult.Yes)
					{
						subtitle_data[sub_indx]._end = new DateTime(mediaplayerCtrl.NaturalDuration.TimeSpan.Ticks).ToString("HH:mm:ss,fff");
						sub_editor_Edited(null, null);
						SubDataList.Focus();
					}
				}
				else
				{
					subtitle_data[sub_indx]._end = subtitle_data[sub_indx + 1]._start;
					MediaPlayerCore.UpdateState("Subtitle Extended!");
					sub_editor_Edited(null, null);
					SubDataList.Focus();
				}
			}

		}

		private void radMenuItem3_Click(object sender, EventArgs e)
		{

			try { LoadSubricTool(Environment.CurrentDirectory + "\\tools\\lywriter.subrictool"); }
			catch (Exception error) { RadMessageBox.Show($"Cannot load subric tool,\r\nError : {error.Message}", "SubricTool Error"); }
		}

		private void floatplayerbuttonClick(object sender, EventArgs e)
		{
			FloatPlayerEnable();
		}
       
		private void radMenuItem4_Click(object sender, EventArgs e)
		{
			try { System.Diagnostics.Process.Start("tools\\subdirect.subrictool"); } catch { }
		}

		public void FloatPlayerEnable()
		{
			if (!isFloatPlayerActive)
			{

				Forms.FloatPlayer floatplayer = new Forms.FloatPlayer();
				floatplayer.SetArea(Player_Panel.Controls);
				floatplayer.FormClosing += (o, e) =>
				{

					Control.ControlCollection getbackcontrols = floatplayer.GetArea();

					for (int i = 0; i < getbackcontrols.Count; i++)
					{
						Player_Panel.Controls.Add(getbackcontrols[i]);
					}
					Player_Panel.Update();

					isFloatPlayerActive = false;

				};
				isFloatPlayerActive = true;
				floatplayer.Show();



			}
		}

		private void API_OpenMedia(Uri video_url)
		{
			OpenMedia();
		}

		private TimeSpan API_GetMoviePosition()
		{
			return mediaplayerCtrl.Position;
		}

		private void API_SetMoviePosition(TimeSpan time_to_set)
		{
			mediaplayerCtrl.Position = time_to_set;
		}

		private void API_PlayMovie()
		{
			mediaplayerCtrl.Play();
		}

		private void API_PauseMovie()
		{
			mediaplayerCtrl.Pause();
		}

		private void API_StopMovie()
		{
			mediaplayerCtrl.Stop();
		}

		private Subtitle_Object[] API_GetSubtitles()
		{
			return subtitle_data.ToArray();
		}

		private void API_SetSubtitles(Subtitle_Object[] Subtitles)
		{
			subtitle_data = Subtitles.ToList();
			SubDataList.Items.Clear();

			foreach (Subtitle_Object sub in subtitle_data)
			{
				RadListDataItem new_virtual_item = new RadListDataItem
				{
					Text = $"{sub._id} - [{sub._start}->{sub._end}] - {sub._text}",
					Tag = sub._id,
					ForeColor = sub._color
				};
				SubDataList.Items.Add(new_virtual_item);
				SubDataList.ScrollToItem(SubDataList.Items[SubDataList.Items.Count - 1]);
				SubDataList.SelectedItem = new_virtual_item;
			}


		}

		private List<string> API_GetLyrics()
		{
			return LyricList.Items.Select(x => x.Text).ToList();
		}

		private void API_SetLyrics(List<string> Lyrics)
		{
			LyricList.Items.Clear();
			foreach (string lyric in Lyrics)
			{
				LyricList.Items.Add(lyric);
			}
		}

		private string API_GetUpcomingLyricText()
		{
			return upcome_output.Text;
		}

		private void API_SetUpcomingLyricText(string upcoming_text)
		{
			upcome_output.Text = upcoming_text;
		}

		private void API_AddSubtitle(Subtitle_Object subtitle)
		{

			subtitle_data.Add(subtitle);

			RadListDataItem new_virtual_item = new RadListDataItem
			{
				Text = $"{subtitle._id} - [{subtitle._start}->{subtitle._end}] - {subtitle._text}",
				Tag = subtitle._id,
				ForeColor = subtitle._color
			};
			SubDataList.Items.Add(new_virtual_item);
			SubDataList.ScrollToItem(SubDataList.Items[SubDataList.Items.Count - 1]);
			SubDataList.SelectedItem = new_virtual_item;
		}

		private void API_AddLyric(string lyric)
		{
			LyricList.Items.Add(lyric);
		}

		private void API_ShowSubricMessageBox(string message, string title, SubricMessageIcon icon)
		{
			RadMessageBox.Show(message, title, MessageBoxButtons.OK, ((RadMessageIcon)(int)icon));
		}

		private void API_ChangeStatus(string status_text)
		{
			state_of_app.Text = status_text;
		}

		private string API_GetSubricAppRoot()
		{
			return Environment.CurrentDirectory;
		}

		private string API_GetPluginFolder()
		{
			return Environment.CurrentDirectory + "\\plugins";
		}

		private void API_GZip_CompressFile(string file, string outputfile)
		{
			byte[] comp = Subric.Compression.GZCompressor.Compress(System.IO.File.ReadAllBytes(file));
			System.IO.File.WriteAllBytes(outputfile, comp);
		}

		private void API_GZip_DecompressFile(string file, string outputfile)
		{
			byte[] decomp = Subric.Compression.GZCompressor.Decompress(System.IO.File.ReadAllBytes(file));
			System.IO.File.WriteAllBytes(outputfile, decomp);
		}

		private void API_ShowVideoStatus(string status)
		{
			MediaPlayerCore.UpdateState(status);
		}

		private void API_ShowSubtitle(string subtitle)
		{
			MediaPlayerCore.ShowSub(subtitle);
		}

		private async void API_ShowSubtitleForMs(string subtitle, int subtitle_time)
		{
			MediaPlayerCore.ShowSub(subtitle);
			await Task.Delay(subtitle_time);
			MediaPlayerCore.HideSub();
		}

		private void API_HideSubtitle()
		{
			MediaPlayerCore.HideSub();
		}

		private void API_SetLyricLoaded()
		{
			isLyricLoaded = true;

		}

		private void API_RegisterCallback(Action callback, string callback_name)
		{
			CallbacksList.Add(new CallbackActionData
			{
				CallbackName = callback_name,
				CallbackAction = callback
			});
		}

		private void API_UnegisterCallback(string callback_name)
		{
			CallbackActionData find_callback = CallbacksList.Find(c => c.CallbackName == callback_name);
			if (find_callback != null)
			{
				CallbacksList.Remove(find_callback);
			}

		}

		private void API_ChangePreviewSubtitleDefaultColor(string colorhex)
		{
			MediaPlayerCore.subtitle_preview.Foreground =
			(System.Windows.Media.SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(colorhex));
		}

		private void API_ResetPreviewSubtitleDefaultColor()
		{
			MediaPlayerCore.subtitle_preview.Foreground = new System.Windows.Media.SolidColorBrush(
			System.Windows.Media.Color.FromRgb(253, 172, 0));
		}
	}
}
