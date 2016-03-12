#pragma once

#include <QtWidgets/QWidget>
#include <QtWidgets/QGraphicsView>
#include <QtWidgets/QGraphicsScene>

class Widget : public QWidget
{
    Q_OBJECT

public:
    Widget(QWidget *parent = 0);
    ~Widget();

private slots:
    void addRect();
    void addCircle();
    void addLine();
    void saveScene();

private:
    QGraphicsView *mView;
    QGraphicsScene mScene;
};
