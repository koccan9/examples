//
//  main.swift
//  Adapter Example1
//
//  Created by ttt on 21.03.2020.
//  Copyright © 2020 ttt. All rights reserved.
//

import Foundation
protocol IMP3player{
    func play()
}
protocol IMP4player{
    func play()
}
class ConcreteMP3player:IMP3player{
    func play() {
        print("MP3 was played")
    }
}
class ConcreteMP4player:IMP4player{//to be used.
    func play() {
        print("MP4 was played")
    }
}
class MP4adapter:IMP4player{
    private let adaptee:IMP3player!
    init(_ adaptee:IMP3player){
        self.adaptee=adaptee
    }
    func play() {
        adaptee.play()
    }
}
func test(){
    let mp3=ConcreteMP3player()
    let mp4=ConcreteMP4player()
    let adapter=MP4adapter(mp3)
    mp4.play()
    adapter.play()
}
test()
