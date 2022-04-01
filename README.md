# PSO2VoiceSampleDownloader
jp: https://pso2.jp/players/news/29013/  
gl: https://pso2.com/players/news/275/  

This program downloads Voice Sample audio files from the PSO2 JP server.  
PSO2 JPサーバーからボイスサンプルファイルをダウンロードするプログラムです。

# 使い方
4種類のテキストファイルを準備します。

 - pso2_voice_t1.txt ヒト型タイプ1
 - pso2_voice_t1.txt ヒト型タイプ2
 - pso2_voice_t1c.txt キャストタイプ1
 - pso2_voice_t2c.txt キャストタイプ2

公式サイトのボイスサンプルページから次の情報を取得し、タブ区切りのテキストファイルにします。

 1. アイテム名称
 2. CV
 3. サンプルボイス1のaudioクラス名
 4. サンプルボイス2のaudioクラス名
 5. サンプルボイス3のaudioクラス名
 
「audioクラス名」はサンプルボイスに対応するaudioタグのクラス名を指定します。(例: 11_voice_ACman01_012)

これらのテキストファイルを実行ファイルのディレクトリに作成し、プログラムを実行するとボイスサンプルを次々とダウンロードします。
ついでにHTMLカタログも作成します。「_catalog.html」ファイルがそれです。
