//
// MainPage.xaml.cpp
// MainPage クラスの実装。
//

#include "pch.h"
#include "MainPage.xaml.h"

using namespace MediaTest01;

using namespace concurrency;
using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

MainPage::MainPage()
{
	InitializeComponent();

	//初期化ここでええのん？
	_rootFolder = Windows::Storage::KnownFolders::MusicLibrary;
}

/// <summary>
/// このページがフレームに表示されるときに呼び出されます。
/// </summary>
/// <param name="e">このページにどのように到達したかを説明するイベント データ。Parameter 
/// プロパティは、通常、ページを構成するために使用します。</param>
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
	(void) e;	// 未使用のパラメーター
}


void MediaTest01::MainPage::Play_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	//Play
	using namespace Windows::Storage;
	using namespace Windows::Storage::Streams;

	auto getFileTask = create_task(_rootFolder->GetFileAsync("sample.wma"));
	Platform::String^ mimeType = nullptr;
	getFileTask.then([&mimeType](StorageFile^ soundFile) {       
		//success
		mimeType = soundFile->ContentType;
		return create_task(soundFile->OpenReadAsync());
	}).then([=](IRandomAccessStream^ randomAccessStream){
		if(randomAccessStream){
			MediaElement1->SetSource(randomAccessStream, mimeType);
		}	
	});

}


void MediaTest01::MainPage::Stop_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	//Stop
	MediaElement1->Stop();

}


void MediaTest01::MainPage::Button_Click_1(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{

}
