#! /usr/bin/env bash

#用于下载B站托管的github上的FFmpeg分支源码和FFmpeg依赖包

# gas-preprocessor => https://github.com/Bilibili/gas-preprocessor.git
# ffmpeg => https://github.com/Bilibili/FFmpeg.git
REMOTE_REPO=$1

#需要下载的远程代码clone到本地的位置（extra/gas-preprocessor，extra/ffmpeg）
LOCAL_WORKSPACE=$2


#会执行二次,分别下载gas-preprocessor和FFmpeg，先下载gas-preprocessor，在下载FFmpeg，因为FFmpeg必须依赖gas-preprocessor

#     判断2个参数是否有值
if [ -z $REMOTE_REPO -o -z $LOCAL_WORKSPACE ]; then
    echo "invalid call pull-repo.sh '$REMOTE_REPO' '$LOCAL_WORKSPACE'"

 #    判断文件是否存在，一开始都不存在
elif [ ! -d $LOCAL_WORKSPACE ]; then

#    克隆源码到本地目录LOCAL_WORKSPACE
    git clone $REMOTE_REPO $LOCAL_WORKSPACE
else
    cd $LOCAL_WORKSPACE
    git fetch --all --tags
    cd -
fi
