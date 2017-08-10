#! /usr/bin/env bash
#
# Copyright (C) 2013-2015 Zhang Rui <bbcallen@gmail.com>
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#      http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
#

# IJK_FFMPEG_UPSTREAM=git://git.videolan.org/ffmpeg.git

#B站托管与github 的ffmpeg 分支的下载地址
IJK_FFMPEG_UPSTREAM=https://github.com/Bilibili/FFmpeg.git

#与上面的变量一样
IJK_FFMPEG_FORK=https://github.com/Bilibili/FFmpeg.git

#ffmpeg版本
IJK_FFMPEG_COMMIT=ff3.1--ijk0.6.1--20160824--001

#ffmpeg 下载目录
IJK_FFMPEG_LOCAL_REPO=extra/ffmpeg

#gas-preprocessor 的下载地址
#gas-preprocessor是用于编译ffmpeg 的perl预处理脚本
IJK_GASP_UPSTREAM=https://github.com/Bilibili/gas-preprocessor.git

# gas-preprocessor backup
# https://github.com/Bilibili/gas-preprocessor.git

if [ "$IJK_FFMPEG_REPO_URL" != "" ]; then
	IJK_FFMPEG_UPSTREAM=$IJK_FFMPEG_REPO_URL
	IJK_FFMPEG_FORK=$IJK_FFMPEG_REPO_URL
fi

if [ "$IJK_GASP_REPO_URL" != "" ]; then
	IJK_GASP_UPSTREAM=$IJK_GASP_REPO_URL
fi

#每个脚本都应该在文件头加上这一句
#用来控制脚本执行，只是有一行语句的执行出错就会退出
set -e

#定义文件目录
TOOLS=tools

#iOS6 架构
FF_ALL_ARCHS_IOS6_SDK="armv7 armv7s i386"

#iOS7架构
FF_ALL_ARCHS_IOS7_SDK="armv7 armv7s arm64 i386 x86_64"

#iOS8架构
FF_ALL_ARCHS_IOS8_SDK="armv7 arm64 i386 x86_64"

#所有架构 = iOS8 架构
FF_ALL_ARCHS=$FF_ALL_ARCHS_IOS8_SDK

#获取脚本第一个参数
FF_TARGET=$1


#定义函数
function echo_ffmpeg_version() {

	#输出 ffmpeg版本号
	echo $IJK_FFMPEG_COMMIT
}

function pull_common() {
	#查看git版本
	git --version
	echo "== pull gas-preprocessor base =="

#   $TOOLS => tools $IJK_GASP_UPSTREAM => https://github.com/Bilibili/gas-preprocessor.git

#   => sh tools/pull-repo-base.sh https://github.com/Bilibili/gas-preprocessor.git extra/gas-preprocessor

#   执行当前文件夹下tools文件夹中的pull-repo-base.sh 并且传入两个参数（https://github.com/Bilibili/gas-preprocessor.git，extra/gas-preprocessor）下载gas-preprocessor
	sh $TOOLS/pull-repo-base.sh $IJK_GASP_UPSTREAM extra/gas-preprocessor

	echo "== pull ffmpeg base =="

#   $TOOLS => tools $IJK_GASP_UPSTREAM => https://github.com/Bilibili/FFmpeg.git IJK_FFMPEG_LOCAL_REPO => extra/ffmpeg
#   => sh tools/pull-repo-base.sh https://github.com/Bilibili/FFmpeg.git extra/ffmpeg
#   执行当前文件夹下tools文件夹中的pull-repo-base.sh 并且传入两个参数（https://github.com/Bilibili/FFmpeg.git，extra/ffmpeg），下载FFmpeg
	sh $TOOLS/pull-repo-base.sh $IJK_FFMPEG_UPSTREAM $IJK_FFMPEG_LOCAL_REPO
}


#用于获取B站托管的github上的FFmpeg分支,根据传入的不同平台架构放置不同工作目录
function pull_fork() {
	#输出平台架构
	echo "== pull ffmpeg fork $1 =="

#   $TOOLS => tools $IJK_FFMPEG_FORK => https://github.com/Bilibili/FFmpeg.git IJK_FFMPEG_LOCAL_REPO => extra/ffmpeg
#   执行tools文件夹下的pull-repo-ref.sh脚本 并且传入3个参数 （https://github.com/Bilibili/FFmpeg.git ， ios/ffmpeg-平台架构 ，extra/ffmpeg）
	sh $TOOLS/pull-repo-ref.sh $IJK_FFMPEG_FORK ios/ffmpeg-$1 ${IJK_FFMPEG_LOCAL_REPO}

	#进入 ffmpeg 平台架构文件
	cd ios/ffmpeg-$1

	#IJK_FFMPEG_COMMIT => ff3.1--ijk0.6.1--20160824--001
	#git checkout ff3.1--ijk0.6.1--20160824--001 -B ijkplayer
	#切换到ffmpeg版本分支，并且强制创建新的分支ijkplayer，
	git checkout ${IJK_FFMPEG_COMMIT} -B ijkplayer

	#回到上一级目录
	cd -
}


#调用4次pull_fork函数，依次传入armv7，arm64，i386，x86_64
function pull_fork_all() {
	# 变量$FF_ALL_ARCHS =  armv7 arm64 i386 x86_64
    # 遍历FF_ALL_ARCHS，依次调用pull_fork函数
	for ARCH in $FF_ALL_ARCHS
	do
		pull_fork $ARCH
	done
}

#----------
#   FF_TARGET => $1
#   执行脚本的时候，没有传任何参数，因此$1 = 空
#   case "$FF_TARGET" in => case "$1" in => case "" in

#   不满足任何条件，执行 *) 后面的语句（执行pull_common，pull_fork_all函数）
case "$FF_TARGET" in
	ffmpeg-version)
		echo_ffmpeg_version
	;;
	armv7|armv7s|arm64|i386|x86_64)
		pull_common
		pull_fork $FF_TARGET
	;;
	all|*)
		pull_common
		pull_fork_all
	;;
esac
