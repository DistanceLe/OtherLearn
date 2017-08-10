#! /usr/bin/env bash

#接收3个脚本参数
#B站自己托管站github的FFmpeg
REMOTE_REPO=$1
#本地目标仓库存放位置
LOCAL_WORKSPACE=$2
#远程ffmpe官方仓库clone到本地的位置
REF_REPO=$3

#  判断3个参数字符串是否为空
if [ -z $1 -o -z $2 -o -z $3 ]; then
    echo "invalid call pull-repo.sh '$1' '$2' '$3'"

#   判断文件是否存在，一开始都不存在，所以执行 git clone --reference $REF_REPO $REMOTE_REPO $LOCAL_WORKSPACE
elif [ ! -d $LOCAL_WORKSPACE ]; then

#   git clone --reference extra/ffmpeg https://github.com/Bilibili/FFmpeg.git ios/ffmpeg-armv7
    git clone --reference $REF_REPO $REMOTE_REPO $LOCAL_WORKSPACE
#    进入到本地仓库目录
    cd $LOCAL_WORKSPACE
#   将版本库未打包的松散对象打包
    git repack -a
else
    cd $LOCAL_WORKSPACE
    git fetch --all --tags
    cd -
fi
